using System;
using CompanyWebManager.Helpers;

namespace Encryption_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var content = "Example test";
            //var key = "E546C8DF278CD5931069B522E695D4F2";
            var key = EncryptHelper.GenerateKey();

            Console.WriteLine(content);
            var encrypted = EncryptHelper.EncryptString(content, key);
            Console.WriteLine(encrypted);

            var decrypted = EncryptHelper.DecryptString(encrypted, key);
            Console.WriteLine(decrypted);

            Console.ReadLine();
        }
    }
}