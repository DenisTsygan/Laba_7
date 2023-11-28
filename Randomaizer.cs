using System;
using System.Linq;

namespace Laba_7
{
    public class Randomaizer
    {
        private static Random _random = new Random();
        /// <summary>
        /// Generate random date
        /// </summary>
        /// <returns></returns>
        public static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }
        /// <summary>
        /// Generate random string 
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int length = _random.Next(1, 15);
            string randomString = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
