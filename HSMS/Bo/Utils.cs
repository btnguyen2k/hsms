using System;
using System.Security.Cryptography;
using System.Text;

namespace HSMS.Bo
{
    public class Utils
    {
        public static int CalcSchoolYear()
        {
            DateTime now = DateTime.Now;
            if (now.Month > 6) return now.Year;
            return now.Year - 1;
        }

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

        private static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static int GetCurrentUnixTimestamp()
        {
            //TODO timezone aware?
            TimeSpan t = DateTime.Now - EPOCH;
            return (int) t.TotalSeconds;
        }

        public static DateTime UnixTimestampToDateTime(int timestamp)
        {
            return EPOCH.AddSeconds(timestamp);
        }
    }
}