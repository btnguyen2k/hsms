using System.Security.Cryptography;

namespace HSMS.Bo
{
    public class Utils
    {
        public static string Md5(string input)
        {
            if (input == null || input == "") return "";

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = x.ComputeHash(bytes);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        static void Main(string[] args)
        {
            System.Console.Out.WriteLine(Md5("abc"));
        }
    }
}
