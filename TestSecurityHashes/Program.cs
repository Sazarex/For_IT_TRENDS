using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        #region 1
        //Console.WriteLine("Password:");
        //string password = Console.ReadLine();

        //string firstHash = HashThePassword(password);

        //Console.WriteLine("Second password:");
        //string password1 = Console.ReadLine();

        //string secontHash = HashThePassword(password1);

        //if (firstHash == secontHash)
        //    Console.WriteLine("Пароли одинаковы.");
        //else
        //    Console.WriteLine("Пароли разные.");
        #endregion

        Console.WriteLine("Password:");
        string password = Console.ReadLine();
        byte[] hashedPas1 = HashThePassword(password);
        Console.WriteLine(Convert.ToBase64String(hashedPas1));


        byte[] bytesfromSTR  = ASCIIEncoding.ASCII.GetBytes(Convert.ToBase64String(hashedPas1));


        Console.WriteLine("Second password:");
        string password1 = Console.ReadLine();

        byte[] hashedPas2 = HashThePassword(password1);

        Console.WriteLine(Convert.ToBase64String(hashedPas2));


        if (IsEqualsHashs(hashedPas1,hashedPas2))
        {
            Console.WriteLine("Пароли одинаковы.");
        }

    }




    static byte[] HashThePassword(string passwordFromStroke)
    {
        #region 11
        //byte[] salt = new byte[128 / 8];
        //using (var rngCsp = new RNGCryptoServiceProvider())
        //{
        //    rngCsp.GetNonZeroBytes(salt);

        //}
        //Console.WriteLine("Сгенерированная соль из RNGCryptoService: " + Convert.ToBase64String(salt));


        //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //    password: passwordFromStroke,
        //    salt: salt,
        //    prf: KeyDerivationPrf.HMACSHA256,
        //    iterationCount: 100000,
        //    numBytesRequested: 256 / 8
        //    ));

        //Console.WriteLine("Сгенерированный ХЕШ:" + hashed);
        //return hashed;
        #endregion

        byte[] source = ASCIIEncoding.ASCII.GetBytes(passwordFromStroke);
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(source);
        return hash;
    }

    static bool IsEqualsHashs(byte[] hash1, byte[] hash2)
    {
        bool answer = false;
        int i = 0;
        while((i < hash2.Length)&& (hash1[i] == hash2[i]))
        {
            i++;
            if (i == hash2.Length)
            {
                answer = true;

            }
        }

        return answer;

    }


}