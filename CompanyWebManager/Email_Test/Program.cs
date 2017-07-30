using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyWebManager.Helpers;
using MimeKit;

namespace Email_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Sendd();


        }

        public static void Sendd()
        {
            EmailSender email = new EmailSender();
            List<string> receivers = new List<string>();
            receivers.Add("pawel.marciniak92@gmail.com");
            receivers.Add("pawel_m_92@wp.pl");

            new Task(() =>
                {
                    //email.SendEmails("webcompanymanager2017@gmail.com", receivers, "test", "dupa", "test", "test");
                }).Start();
            




            //Task task2 =  email.ReceiveEmails("test", "test");

            //email.ReceiveEmail("test", "test");

            //task.Wait();

        }
    }
}