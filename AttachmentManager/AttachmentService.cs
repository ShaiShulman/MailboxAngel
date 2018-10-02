using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace AttachmentManager
{
    public class AttachmentService
    {
        public event EventHandler<AttachmentsProgressInitiatedEventArgs> AttachmentsProgressInitiated;
        public event EventHandler<EventArgs> AttachmentProgressIncrement;
        public event EventHandler<AttachmentsFinishedEventArgs> AttachmentsFinished;

        private object _uiElement;
        public object UIElement
        {
            get { return _uiElement; }
            set { _uiElement = value; }
        }

        private MailItem _message;
        private Queue<string> _usedFiles;

        public AttachmentService(MailItem message)
        {
            _message = message;
            _usedFiles = new Queue<string>();
        }

        ~AttachmentService()
        {
            while (_usedFiles.Count>0)
            {
                string file = _usedFiles.Dequeue();
                File.Delete(file);
                DirectoryInfo folder = new DirectoryInfo(Path.GetDirectoryName(file));
                if (folder.GetFiles().Count() == 0)
                    folder.Delete();
            }
        }

        public List<AttachmentCommand> getAttachments()
        {
            List<AttachmentCommand> items = new List<AttachmentCommand>();
            foreach (var source in _message.Attachments)
            {
                if (source is Attachment && !isInlineAttachment((Attachment)source))
                   items.Add(new ExistingAttachmentCommand((Attachment)source));
            }
            return items;
        }

        public bool isInlineAttachment(Attachment attach)
        {
            const string PR_ATTACH_METHOD = @"http://schemas.microsoft.com/mapi/proptag/0x37050003";
            const string PR_ATTACH_FLAGS = @"http://schemas.microsoft.com/mapi/proptag/0x37140003";
            //if (!(attach.Parent) is MailItem)
            //    return false;
            MailItem message = (Microsoft.Office.Interop.Outlook.MailItem)attach.Parent;
            bool result = ((message.BodyFormat == OlBodyFormat.olFormatRichText
                        && attach.PropertyAccessor.GetProperty(PR_ATTACH_METHOD) == 6)
                    ||
                    (message.BodyFormat == OlBodyFormat.olFormatHTML
                        && attach.PropertyAccessor.GetProperty(PR_ATTACH_FLAGS) == 4))
                    ||
                    message.HTMLBody.Contains("cid:" + attach.FileName);
            return result; 
        }

        public void CreateAttachmentsList(List<AttachmentCommand> attachments)
        {
            string listContent;
            switch (_message.BodyFormat)
            {
                case OlBodyFormat.olFormatHTML:
                    listContent = "<br><table>";
                    break;
                case OlBodyFormat.olFormatPlain:
                case OlBodyFormat.olFormatRichText:
                    listContent = "\n";
                    break;
                default:
                    listContent = "\n";
                    break;
            }
            for (int i = 0; i < attachments.Count; i++)
            {
                switch (_message.BodyFormat)
                {
                    case OlBodyFormat.olFormatHTML:
                        listContent = String.Concat(listContent, string.Format("<tr><td>{1}</td><td>{0}</td><td><a href='{0}'>{0}</a></td></tr>", attachments[i].FullName,i+1));
                        break;
                    case OlBodyFormat.olFormatPlain:
                        listContent = String.Concat(listContent, string.Format("{0}. \t {1}\r\n", i + 1, attachments[i].FullName));
                        break;
                    case OlBodyFormat.olFormatRichText:
                        listContent = String.Concat(listContent, string.Format("{0}. \t {1}\t\r\n", i+1, attachments[i].FullName));
                        break;
                }
            }
            switch (_message.BodyFormat)
            {
                case OlBodyFormat.olFormatHTML:
                    _message.HTMLBody = string.Concat(listContent, "</table><br>", _message.HTMLBody);
                    break;
                case OlBodyFormat.olFormatPlain:
                    _message.Body = string.Concat(listContent, _message.Body);
                    break;
                case OlBodyFormat.olFormatRichText:
                    List<byte> body = new List<byte>();
                    body.AddRange(Encoding.ASCII.GetBytes(listContent));
                    body.AddRange(_message.RTFBody);
                    _message.RTFBody = body.ToArray();
                    break;
            }

        }
        public void ProcessAttachments(List<AttachmentCommand> attachments)
        {
            int progressMax = attachments.Count * 2 + 1 + attachments.OfType<ExistingAttachmentCommand>().Count();
            onAttachmentProcessInitiated(progressMax);
            Queue<string> files = new Queue<string>();
            onAttachmenProgressIncrement();
            string baseFolder = Files.getUniqueTempFolder();
            Microsoft.Office.Interop.Word.Application wordApp=null;
            if (attachments.Exists(x => x.FinalizeChanges))
                wordApp = new Microsoft.Office.Interop.Word.Application();
            _message.HTMLBody = _message.HTMLBody;
            foreach (var item in attachments)
            {
                onAttachmenProgressIncrement();
                if (item is ExistingAttachmentCommand)
                {
                    if (!item.Remove)
                    {
                        string fileName = Files.getUniqueFileName(baseFolder, item.NewName);
                        ((ExistingAttachmentCommand)item).Attachment.SaveAsFile(fileName);
                        if (item.FinalizeChanges)

                            finalizeWordDoc(fileName, wordApp);
                        files.Enqueue(fileName);
                    }
                    ((ExistingAttachmentCommand)item).Attachment.Delete();
                }
                else if (item is NewAttachmentCommand)
                {
                    string sourceFile= (((NewAttachmentCommand)item).FilePath);
                    string targetFile = Files.getUniqueFileName(baseFolder, item.NewName);
                    File.Copy(sourceFile, targetFile);
                    files.Enqueue(targetFile);
                }
            }
            int totalFiles = files.Count;
            while (files.Count>0)
            {
                onAttachmenProgressIncrement();
                string fileName = files.Dequeue();
                try
                {
                    _message.Attachments.Add(fileName);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show(ex.Message, "Outlook Helper", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    File.Delete(fileName);
                }
            }
            if (Directory.GetFiles(baseFolder).Count()==0)
                Directory.Delete(baseFolder);
            if (wordApp != null)
                wordApp = null;
            onAttachmentsFinished();
        }

        public void OpenAttachmente(AttachmentCommand attachment)
        {
            string fileName;
            if (attachment is ExistingAttachmentCommand)
            {
                string baseFolder = Files.getUniqueTempFolder();
                fileName = Path.Combine(baseFolder, (attachment as ExistingAttachmentCommand).Attachment.FileName);
                (attachment as ExistingAttachmentCommand).Attachment.SaveAsFile(fileName);
            }
            else if (attachment is NewAttachmentCommand)
            {
                fileName=(attachment as NewAttachmentCommand).FilePath;
            }
            else
                return;
            _usedFiles.Enqueue(fileName);
            try
            {
                Process.Start(fileName);
            }
            catch (System.Exception)
            {
                                //    throw;
            }
        }
 
        private void finalizeWordDoc(string filename, Microsoft.Office.Interop.Word.Application wordApp)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException();
            Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Open(filename);
            document.AcceptAllRevisions();
            document.Range().HighlightColorIndex = WdColorIndex.wdNoHighlight;
            document.Save();
            document.Close();
        }

        #region EventHandlers

        protected void onAttachmenProgressIncrement()
        {
            if (AttachmentProgressIncrement != null)
                AttachmentProgressIncrement(this, EventArgs.Empty);
        }

        protected void onAttachmentsFinished()
        {
            if (AttachmentsFinished != null)
                AttachmentsFinished(this, new AttachmentsFinishedEventArgs(_uiElement));
        }

        protected void onAttachmentProcessInitiated(int items)
        {
            if (AttachmentsProgressInitiated != null)
                AttachmentsProgressInitiated(this, new AttachmentsProgressInitiatedEventArgs(items));
        }

        #endregion

    }

    #region EventArgs
    public class AttachmentsFinishedEventArgs : EventArgs
    {
        private object _uiElement;
        public object UIElement
        {
            get { return _uiElement; }
            set { _uiElement = value; }
        }


        public AttachmentsFinishedEventArgs(object uiElement)
        {
            _uiElement = uiElement;
        }

    }

    public class AttachmentsProgressInitiatedEventArgs : EventArgs
    {
        private int _itemsCount;
        public int ItemsCount
        {
            get { return _itemsCount; }
            set { _itemsCount = value; }
        }
        public AttachmentsProgressInitiatedEventArgs(int itemsCount)
        {
            _itemsCount = itemsCount;
        }

    }

    #endregion
}
