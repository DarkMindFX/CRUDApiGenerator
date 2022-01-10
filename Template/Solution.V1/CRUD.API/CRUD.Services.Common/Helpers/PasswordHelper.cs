using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PPT.Services.Common.Helpers
{
    public class PasswordHelper
    {
        public static string GenerateHash(string password, string salt)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentException("Salt cannot be empty");
            }

            byte[] hash = GenerateSaltedHash(Encoding.UTF8.GetBytes(password.ToArray()), Encoding.UTF8.GetBytes(salt.ToArray()));

            return System.Convert.ToBase64String(hash);
        }

        public static string GenerateSalt(uint length)
        {
            if(length < 1)
            {
                throw new ArgumentException("Length must be greater or equal 1");
            }

            StringBuilder salt = new StringBuilder(string.Empty);
            Random rnd = new Random();
            for(int i = 0; i < length; ++i)
            {
                char c = (char)rnd.Next(65, 90);
                salt.Append(c);
            }

            return salt.ToString();
        }

        static byte[] GenerateSaltedHash(byte[] text, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] textWithSalt =
              new byte[text.Length + salt.Length];

            text.CopyTo(textWithSalt, 0);
            salt.CopyTo(textWithSalt, text.Length);

            return algorithm.ComputeHash(textWithSalt);
        }
    }
}
