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
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int result = int.MinValue;
        for (int row = 1; row < 5; row++)
        {
            for (int column = 1; column < 5; column++)
            {
                result = Math.Max(result, Result.getHourglass(arr, row, column));
            }
        }
        return result;
    }

    private static int getHourglass(List<List<int>> arr, int row, int column)
    {
        int result = arr[row - 1][column - 1] + arr[row - 1][column] + arr[row - 1][column + 1]; //First Line
        result += arr[row][column]; //Middle
        result += arr[row + 1][column - 1] + arr[row + 1][column] + arr[row + 1][column + 1]; //Last Line

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
