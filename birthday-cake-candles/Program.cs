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
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

            int result = birthdayCakeCandles(candles);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        private static int birthdayCakeCandles(List<int> candles)
        {
            var tallestCount = 0;
            var tallestValue = 0;

            for (int x = 0; x < candles.Count; x++)
            {
                if (candles[x] > tallestValue)
                {
                    tallestValue = candles[x];
                    tallestCount = 1;
                }
                else if (candles[x] == tallestValue) tallestCount++;
            }

            return tallestCount;
        }
    }
}