using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper
{
    class SignaturesService
    {
        const string SIGNATURES_SUBFOLDER = @"Microsoft\Signatures";
        const string SIGNATURE_HTML_HEADER = @"<html xmlns:v=";
        const string SINGNATURE_HTML_FOOTER = "</html>";
        const string SIGNATURE_CLASS_NAME= "data-outlook-signature";
        private string getSignaturesFolder()
        {
            string path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SIGNATURES_SUBFOLDER);
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(string.Format("{0} not found!",path));
            return path;
        }
        public string GetSignaturePath(string name, SignatureType type)
        {
            string path = getSignaturesFolder();
            string extension;
            switch (type)
            {
                case SignatureType.HTML:
                    extension = ".htm";
                    break;
                case SignatureType.RTF:
                    extension = ".rtf";
                    break;
                case SignatureType.Text:
                default:
                    extension = ".txt";
                    break;
            }
            string fullpath = string.Format(@"{0}\{1}{2}", path, name, extension);
            if (!File.Exists(fullpath))
                throw new FileNotFoundException(fullpath);
            return fullpath;
        }
        public string[] GetSignatures()
        {
            string path = getSignaturesFolder();
            if (string.IsNullOrWhiteSpace(path))
                return null;
            DirectoryInfo sigFolder = new DirectoryInfo(path);
            List<string> files = new List<string>();
            foreach (var file in sigFolder.EnumerateFiles("*.htm"))
            {
                files.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            return files.ToArray();
        }

        private string getImagesinHTML(string html,Attachments attachments)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            List<string> files=new List<string>();
            string baseFolder = getSignaturesFolder();
            foreach (var item in document.DocumentNode.SelectNodes("//img"))
            {
                string src = item.Attributes["src"].Value;
                string path = Path.Combine(baseFolder, src.Replace("%20", " ").Replace("/", @"\"));
                if (File.Exists(path))
                {
                    if (src.IndexOf("/") > -1)
                        item.Attributes["src"].Value = "cid:img567.png@embed";

                    Attachment attach =attachments.Add(path, OlAttachmentType.olByValue,1);
                    attach.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/png");
                    attach.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "img567.png@embed");
                    attachments.Parent.Save();
                    
                }
                
              

                //item.Attributes["src"].Value = string.Concat("cid:", src.Substring(src.IndexOf("/") + 1) /*,"@123"*/);
                //item.Attributes["src"].Value = src.Substring(src.IndexOf("/") + 1);
                else
                    item.Attributes["src"].Value = src;
            }
            //foreach (var item in document.DocumentNode.SelectNodes("//imagedata"))
            //{
            //    item.Attributes["src"].Value = "cid:img567.png@123";
            //}
            html = document.DocumentNode.InnerHtml;
            return html;
        }

        private void markHTMLsignaturesinFolder()
        {
            string[] signatures = GetSignatures();
            foreach (var item in signatures)
            {
                string sigText = loadSignature(item, SignatureType.HTML);
                HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(sigText);
                html.DocumentNode.ChildNodes.Insert(0, html.CreateElement("<span>&nbsp;&nbsp;&nbsp;&nbsp;</span>"));
                //    HtmlAgilityPack.HtmlNodeCollection htmlNodes = html.DocumentNode.SelectNodes(string.Format("//*[not(@{0}='true')]", SIGNATURE_CLASS_NAME));
                //    if (htmlNodes != null)
                //    {
                //        foreach (var element in htmlNodes)
                //        {
                //            element.Attributes.Add(SIGNATURE_CLASS_NAME,"true");
                //        }
                //        html.Save(GetSignaturePath(item, SignatureType.HTML));
                //    }
                //}
                html.Save(GetSignaturePath(item, SignatureType.HTML));
            }
        }
        private string removeExistingSignature(string htmlBody)
        {
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(htmlBody);
            bool found = false;
            //foreach (HtmlAgilityPack.HtmlNode node in html.DocumentNode.SelectSingleNode("//body").SelectNodes("/*"))
            foreach (HtmlAgilityPack.HtmlNode node in html.DocumentNode.SelectNodes("/body/*"))
                {
                    if (found)
                    node.Remove();
                else if (node.InnerText == "&nbsp;&nbsp;&nbsp;&nbsp;")
                    found = true;
            }
            //HtmlAgilityPack.HtmlNodeCollection htmlNodes = html.DocumentNode.SelectNodes(string.Format("//*[(@{0}}='true')]", SIGNATURE_CLASS_NAME));
            //if (htmlNodes != null)
            //{
            //    foreach (var element in htmlNodes)
            //    {
            //        element.Remove();
            //    }
            //}
            return html.DocumentNode.InnerHtml;
        }
        public void UpdateExistingSignature()
        {
            markHTMLsignaturesinFolder();
        }
        public void CheckForInternalSignature(Microsoft.Office.Interop.Outlook.MailItem mail)
        {
            string internalSignature = Properties.AddinSettings.Default.EmailSignatureInternalName;
            if (String.IsNullOrWhiteSpace(internalSignature))
                return;
            string[] internalDomains = Properties.AddinSettings.Default.InternalDomainNames.Split(',');
            int internalRecepients = 0;
            foreach (Recipient recepient in mail.Recipients)
            {
                bool found=false;
                int n = 0;
                do
                {
                    if (recepient.Address.ToString().ToLower().Contains(internalDomains[n].ToLower()))
                    {
                        internalRecepients++;
                        found = true;
                    }
                    n++;
                } while (!found && n < internalDomains.Count());
            }
            if (internalRecepients+1> mail.Recipients.Count/2)
            {
                SignatureType type= SignatureType.Text;
                switch (mail.BodyFormat)
                {
                    case OlBodyFormat.olFormatUnspecified:
                    case OlBodyFormat.olFormatPlain:
                        type = SignatureType.Text;
                        break;
                    case OlBodyFormat.olFormatHTML:
                        type = SignatureType.HTML;
                        break;
                    case OlBodyFormat.olFormatRichText:
                        type = SignatureType.RTF;
                        break;
                }
                string SignatureText = loadSignature(internalSignature, type);
                switch (type)
                {
                    case SignatureType.HTML:
                        int bodyEnds = mail.HTMLBody.LastIndexOf("</body>", StringComparison.CurrentCultureIgnoreCase);
                        SignatureText = getImagesinHTML(SignatureText, mail.Attachments);
                        mail.HTMLBody = String.Concat(removeExistingSignature(mail.HTMLBody),
                            SignatureText);
                        //mail.HTMLBody = String.Concat(mail.HTMLBody.Substring(0, bodyEnds),
                        //    SignatureText,
                        //    mail.HTMLBody.Substring(bodyEnds));
                        break;
                    case SignatureType.RTF:
                        mail.RTFBody = String.Concat(mail.RTFBody, SignatureText);
                        break;
                    case SignatureType.Text:
                        mail.Body = String.Concat(mail.HTMLBody, SignatureText);
                        break;
                }
            }
        }

        private string loadSignature(string name, SignatureType type)
        {
            string filename = GetSignaturePath(name, type);
            string text = System.IO.File.ReadAllText(filename);
            return text;
        }
    }
    enum SignatureType
    {
        HTML,
        RTF,
        Text
    }
}
