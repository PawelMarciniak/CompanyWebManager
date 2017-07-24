using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Models;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;


namespace CompanyWebManager.Helpers
{
    public class EmailSender
    {

        //public Email

        public async Task SendEmailAsync(string emailFrom, string emailTo, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(emailFrom));
            emailMessage.To.Add(new MailboxAddress(emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 465, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                //client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("pawel.marciniak92@gmail.com", "zxcDsa!2");

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
