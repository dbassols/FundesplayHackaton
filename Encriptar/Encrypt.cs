using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace David_Bassols_Hackaton_Backend.Encriptar
{
    public class Encrypt
    {
        static string secretKey1 = "abcdefgh";
        static string secretKey2 = "12345678";


        public static string Decrypt(string encrypted)
        {
            byte[] data = System.Convert.FromBase64String(encrypted);
            byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes(secretKey1);
            byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes(secretKey2);

            MemoryStream memoryStream = new MemoryStream(data.Length);

            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                   desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV),
                                   CryptoStreamMode.Read);

            memoryStream.Write(data, 0, data.Length);
            memoryStream.Position = 0;

            string decrypted = new StreamReader(cryptoStream).ReadToEnd();

            cryptoStream.Close();

            return decrypted;
        }

        public static string Encryptar(string decrypted)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(decrypted);
            byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes(secretKey1);
            byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes(secretKey2);

            MemoryStream memoryStream = new MemoryStream(1024);

            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV),
                                                CryptoStreamMode.Write);

            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] result = new byte[(int)memoryStream.Position];

            memoryStream.Position = 0;
            memoryStream.Read(result, 0, result.Length);
            cryptoStream.Close();

            return System.Convert.ToBase64String(result);
        }
    }
}