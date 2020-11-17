using System;

namespace HackerRank
{
    public static class Solution
    {
        // Complete the miniMaxSum function below.
        static void miniMaxSum(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            long sum = 0;

            for (int x = 0; x < arr.Length; x++)
            {
                if (arr[x] < min) min = arr[x];
                if (arr[x] > max) max = arr[x];
                sum += arr[x];
            }

            Console.WriteLine($"{sum - max} {sum - min}");
        }

        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }
    }
}