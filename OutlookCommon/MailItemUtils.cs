using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailboxAngel.OutlookCommon
{
    class MailItemUtils
    {
        public string GetSenderEmailAddress(MailItem msg)
        {
            AddressEntry sender = msg.Sender;
            string SenderEmailAddress = "";

            if (sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeUserAddressEntry || sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
            {
                ExchangeUser exchUser = sender.GetExchangeUser();
                if (exchUser != null)
                {
                    SenderEmailAddress = exchUser.PrimarySmtpAddress;
                }
            }
            else
            {
                SenderEmailAddress = msg.SenderEmailAddress;
            }

            return SenderEmailAddress;
        }
    }
}
