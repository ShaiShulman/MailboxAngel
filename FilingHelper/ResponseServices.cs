using AttachmentManager;
using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
    public class ResponseServices
    {
        public void ReplyAttachments(MailItem original, bool replyAll)
        {
            AttachmentService attachSrv = new AttachmentService(original);
            MailItem reply = replyAll?original.ReplyAll():original.Reply();
            reply.Display();
            if (original.Attachments.Count > 0)
            {
                Queue<string> files = new Queue<string>();
                string baseFolder = Files.GetUniqueTempFolder();
                foreach (Attachment attach in original.Attachments)
                {
                    if (!attachSrv.isInlineAttachment(attach))
                    {
                        string ext = "";
                        if (attach.FileName.LastIndexOf(".") > 0)
                            ext = attach.FileName.Substring(attach.FileName.LastIndexOf("."));

                        string fileName = Files.GetUniqueFileName(baseFolder, attach.FileName);
                        attach.SaveAsFile(fileName);
                        files.Enqueue(fileName);
                        reply.Attachments.Add(fileName);
                    }
                }
                while (files.Count > 0)
                {
                    string fileName = files.Dequeue();
                    File.Delete(fileName);
                }
                if (Directory.GetFiles(baseFolder).Count() == 0)
                    Directory.Delete(baseFolder);
            }
            reply.Display();
        }

        public void QuoteEmails(List<MailItem> originals)
        {
            MailItem outgoing = Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
            foreach (MailItem item in originals)
            {
                outgoing.Attachments.Add(item);
            }

        }
    }
}
