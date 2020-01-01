using Bridgebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Bridgebooks.Helpers
{
    public class EmailHelper
    {
        public bool SendEmail(ContactViewModel model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();

            message.To.Add(new MailAddress("billadams1977@gmail.com"));
            message.ReplyToList.Add(new MailAddress(model.Email));
            message.From = new MailAddress("info@bridgebookslls.com");
            message.Subject = "New Message From Bridgebooks LLC";
            message.Body = string.Format(body, model.Name, model.Email, model.Comments);
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

    }
}