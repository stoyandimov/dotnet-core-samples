using System.IO;
using Microsoft.AspNetCore.DataProtection;
using System;

namespace core.dataProtection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Short term provider 
            IDataProtectionProvider provider = new EphemeralDataProtectionProvider();
            //or long term provider from Extensions
            provider = DataProtectionProvider.Create(nameof(Main));

            var protector = provider.CreateProtector("encrypt");

            // Write
            File.WriteAllText("C:\\temp\\protected.txt", protector.Protect("Secret Text"));
            //return;

            // Read
            var secret = protector.Unprotect(File.ReadAllText("C:\\temp\\protected.txt"));
            Console.WriteLine(secret);
        }
    }
}
