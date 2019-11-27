using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Services
{
    public static class PasswordHashing
    {
        public static string HashPassword(string password)
        {
            var bytes = Encoding.Unicode.GetBytes(password);
            var inArray = HashAlgorithm.Create("SHA1")?.ComputeHash(bytes);
            return Convert.ToBase64String(inArray ?? throw new InvalidOperationException());
        }
       
    }
}
