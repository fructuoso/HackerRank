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

class Solution
{

    // Complete the reverseArray function below.
    static int[] reverseArray(int[] a)
    {
        //return a.Reverse().ToArray();

        int[] result = new int[a.Length];

        for (int i = a.Length; i > 0; i--)
        {
            result[a.Length - i] = a[i - 1];
        }

        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int[] res = reverseArray(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
