using Bridgebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Bridgebooks.Helpers
{
    public class EmailHelper
    {
        private const string TOEMAIL = "bridgebooksllc@gmail.com";
        private const string FROMEMAIL = "bridgebooksllc@gmail.com";
        private const string SUBJECT = "New Message From Bridgebooks LLC";

        public bool SendEmail(ContactViewModel viewModel)
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress("billadams1977@gmail.com"));
            message.To.Add(new MailAddress(TOEMAIL));
            message.ReplyToList.Add(new MailAddress(viewModel.Email));
            message.From = new MailAddress(FROMEMAIL);
            message.Subject = SUBJECT;
            message.Body = CreateMessageBodyTemplate(viewModel);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Send(message);
                }
                catch(Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        private string CreateMessageBodyTemplate(ContactViewModel model)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<p>From:  {model.Name}</p>");
            sb.Append($"<p>Email: {model.Email}</p>");
            sb.Append($"<p>Phone: {((!String.IsNullOrEmpty(model.Phone)) ? model.Phone : "Not provided")}</p>");
            sb.Append($"<p>Message:</p><p>{model.Comments}</p>");

            return sb.ToString();
        }

    }
}