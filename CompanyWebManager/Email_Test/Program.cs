using System;
using System.Threading.Tasks;
using CompanyWebManager.Helpers;

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

            //Task task = email.SendEmailAsync("pawel.marciniak92@gmail.com", "pawel.marciniak92@gmail.com", "test", "test1234");
            //Task task =  email.ReceiveEmail();

            //task.Wait();

        }
    }
}