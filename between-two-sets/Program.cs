using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    private static int MMC(int num1, int num2) {
        int a = num1;
        int b = num2;
        int mod = 0;

        do
        {
            mod = a % b;
            a = b;
            b = mod;
        } while (mod != 0);

        return ( num1 * num2) / a;
    }

    public static int getTotalX(List<int> a, List<int> b)
    {
        int result = 0;

        int minMultipleCommon = a.Min();

        a.Sort();
        b.Sort();

        for (int i = 0; i < a.Count() - 1; i++)
        {
            minMultipleCommon = MMC(minMultipleCommon, a[i+1]);
        }

        for (int i = minMultipleCommon; i <= b.Min(); i += minMultipleCommon)
        {
            bool divisible = true;
            for (int y = 0; y < b.Count(); y++)
            {
                if (b[y] % i != 0)
                {
                    divisible = false;
                    break; 
                }
            }

            if (divisible)
            {
                Console.WriteLine($"{i} is Divisible");
                result++;
            }
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);
        Console.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
