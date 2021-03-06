﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using MimeKit;


namespace CompanyWebManager.Helpers
{
    public class EmailHelper
    {

        public async Task<bool> Send(Email emailToSend, string login, string pass)
        {
            var emailMessage = new MimeMessage();
            List<string> emptyList = new List<string>();

            string emailLogin = login == null ? "webcompanymanager2017@gmail.com" : login;

            List <string> emailTo = !string.IsNullOrEmpty(emailToSend.Receiver) ? emailToSend.Receiver.Split(';').ToList() : emptyList;
            List<string> emailCc = !string.IsNullOrEmpty(emailToSend.CarbonCopy) ? emailToSend.CarbonCopy.Split(';').ToList() : emptyList;
            List<string> emailBcc = !string.IsNullOrEmpty(emailToSend.BlindCarbonCopy) ? emailToSend.BlindCarbonCopy.Split(';').ToList() : emptyList; 


            emailMessage.From.Add(new MailboxAddress(emailLogin));
            emailMessage.To.Add(new MailboxAddress(emailTo[0]));


            if (emailTo.Count > 1)
            { 
                List<InternetAddress> lists = new List<InternetAddress>();
                foreach (var email in emailTo.Skip(1))
                {
                    lists.Add(InternetAddress.Parse(email));
                    emailMessage.To.AddRange(lists);
                }
            }

            if (emailCc.Any())
            {
                emailMessage.Cc.Add(new MailboxAddress(emailCc[0]));

                if (emailCc.Count > 1)
                {
                    List<InternetAddress> lists = new List<InternetAddress>();
                    foreach (var email in emailCc.Skip(1))
                    {
                        lists.Add(InternetAddress.Parse(email));
                        emailMessage.Cc.AddRange(lists);
                    }
                }
            }


            if (emailBcc.Any())
            {
                emailMessage.Cc.Add(new MailboxAddress(emailBcc[0]));

                if (emailBcc.Count > 1)
                {
                    List<InternetAddress> lists = new List<InternetAddress>();
                    foreach (var email in emailBcc.Skip(1))
                    {
                        lists.Add(InternetAddress.Parse(email));
                        emailMessage.Cc.AddRange(lists);
                    }
                }
            }

            emailMessage.Subject = emailToSend.Subject;
            emailMessage.Body = new TextPart("plain") { Text = emailToSend.Message };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync("smtp.gmail.com", 587);
                    if (string.IsNullOrEmpty(pass))
                    {
                        await client.AuthenticateAsync("webcompanymanager2017@gmail.com", "PawelNa100%");
                    }
                    else
                    {
                        await client.AuthenticateAsync(emailLogin, pass);
                    }
                    
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public async Task<List<Email>> ReceiveEmails(string login, string pass)
        {
            List<Email> messages = new List<Email>();

            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("imap.gmail.com", 993, true);
                if (string.IsNullOrEmpty(login))
                {
                    await client.AuthenticateAsync("webcompanymanager2017@gmail.com", "PawelNa100%");
                }
                else
                {
                    await client.AuthenticateAsync(login, pass);
                }

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                foreach (var uid in client.Inbox.Search(SearchQuery.NotSeen))
                {
                    var message = inbox.GetMessage(uid);

                    messages.Add(MapEmails(message, uid));
                }

                client.Disconnect(true);
                return messages;
            }
        }

        public  void SetEmailAsRead(string id)
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("webcompanymanager2017@gmail.com", "PawelNa100%");

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                var uids = inbox.Search(SearchQuery.HeaderContains("Message-Id", id));
                inbox.AddFlags(uids, MessageFlags.Seen, silent: true);

                
                client.Disconnect(true);
            }
        }

        public void DeteleEmail(string id)
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("webcompanymanager2017@gmail.com", "PawelNa100%");

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                var uids = inbox.Search(SearchQuery.HeaderContains("Message-Id", id));
                inbox.AddFlags(uids, MessageFlags.Deleted, silent: true);


                client.Disconnect(true);
            }
        }

        public Email MapEmails(MimeMessage message, UniqueId uid)
        {
            Email email = new Email();

            email.Message = message.TextBody;
            email.Sender = message.From.ToString();
            email.CarbonCopy = message.Cc.ToString();
            email.ReceivedTime = message.Date.DateTime;
            email.Subject = message.Subject;
            email.Uid = message.MessageId;
            email.Saved = false;

            return email;
        }

        public async Task<Email> GetEmailToDisplay(int rowNum, bool saved, ApplicationDb context, ISession session)
        {
            int ownerId = session.GetObjectFromJson<int>("ownerID");
            return saved ? await context.Emails.SingleOrDefaultAsync(m => m.ID == rowNum) : session.GetItemOfSessionList<Email>("ReceivedEmails-" + ownerId, rowNum);
        }
    }
}
