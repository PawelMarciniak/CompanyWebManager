﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Models;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.CodeAnalysis.Emit;
using MimeKit;


namespace CompanyWebManager.Helpers
{
    public class EmailSender
    {

        //public Email

        public async Task SendEmail(string emailFrom, List<string> emailTo, string subject, string message, string login, string pass)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(emailFrom));

            emailMessage.To.Add(new MailboxAddress(emailTo[0]));

            if (!(emailTo.Count > 1))
            {
                foreach (var email in emailTo.Skip(1))
                {
                    emailMessage.Bcc.Add(new MailboxAddress(email));
                }
            }
            
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                 await client.ConnectAsync("smtp.gmail.com", 587);
                //client.Authenticate(login, pass);
                await client.AuthenticateAsync("webcompanymanager2017@gmail.com", "PawelNa100%");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public async Task ReceiveEmails(string login, string pass)
        {
            List<Email> messages = new List<Email>();

            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("imap.gmail.com", 993, true);
                //await client.AuthenticateAsync(login, pass);
                await client.AuthenticateAsync("webcompanymanager2017@gmail.com", "PawelNa100%");

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                for (int i = 0; i < inbox.Unread; i++)
                {
                    var message  = inbox.GetMessage(i);

                    messages.Add(MapEmails(message));

                    //Console.WriteLine("Subject: {0}", message.Subject);
                }

                client.Disconnect(true);
            }
        }

        public Email MapEmails(MimeMessage message)
        {
            Email email = new Email();

            email.Message = message.TextBody;
            email.Sender = message.Sender.ToString();
            email.CarbonCopy = message.Cc.ToString();
            email.ReceivedTime = message.Date.DateTime;
            email.Subject = message.Subject;

            return email;
        }
    }
}
