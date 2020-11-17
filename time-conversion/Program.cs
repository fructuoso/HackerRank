using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank
{
    public static class Solution
    {
        public static void Main(string[] args)
        {

            string s = Console.ReadLine();

            string result = timeConversion(s);
            
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            tw.WriteLine(result);

            tw.Flush();
            tw.Close();
        }

        private static string timeConversion(string s)
        {
            int hour = Convert.ToInt32(s.Substring(0, 2));
            int minute = Convert.ToInt32(s.Substring(3, 2));
            int second = Convert.ToInt32(s.Substring(6, 2));

            string period = s.Substring(8, 2);

            if (period == "PM" && hour < 12) hour += 12;
            if (period == "AM" && hour >= 12) hour -= 12;

            return $"{hour:00}:{minute:00}:{second:00}";
        }
    }
}