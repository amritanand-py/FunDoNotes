using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace CommonLayer.Encryption
{
    public static class EncryptDecryptClass
    {
        public static string EncryptionPass(string Password)
        {
            Random rand = new Random();
            int saltLength = rand.Next(10,13);
            string genratedSalt = BC.GenerateSalt(saltLength);
            string hashPassword = BC.HashPassword(Password, genratedSalt);
            return hashPassword;
        }

        public static bool MatchPass(string hashPassword,string password)
        {
            if (hashPassword == null || password == null) { return false; }
            if (BC.Verify(password, hashPassword))
            {
                return true;
            }
            return false;
        }

    }

   
}
