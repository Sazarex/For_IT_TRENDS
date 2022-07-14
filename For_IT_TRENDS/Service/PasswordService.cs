using System.Text;
using System.Security.Cryptography;

namespace For_IT_TRENDS.Service
{
    public static class PasswordService
    {
        public static bool IsPasswordsEquals(string password, string passwordHashFromDb)
        {
            bool result = false;


            byte[] source = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashedPassword = new MD5CryptoServiceProvider().ComputeHash(source);

            string hashedPasswordString = Convert.ToBase64String(hashedPassword);

            if (hashedPasswordString == passwordHashFromDb)
                result = true;

            return result;

        }
    }
}
