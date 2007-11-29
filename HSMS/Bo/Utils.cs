using System;
using System.Security.Cryptography;
using System.Text;

namespace HSMS.Bo
{
    public class Utils
    {
        public static string Md5(string input)
        {
            if (input == null || input == "") return "";

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            bytes = x.ComputeHash(bytes);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bytes)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        private static void Main(string[] args)
        {
            Console.Out.WriteLine(Md5("abc"));
        }
    }
}