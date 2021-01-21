using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    // Complete the solve function below.
    static int[] solve(int[] arr, int[] queries)
    {
        int[] response = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            response[i] = solve(arr, queries[i]);
        }

        return response;
    }

    static int solve(int[] arr, int query)
    {
        int response = arr.Take(query).Max();

        for (int currentPosition = query + 1; currentPosition <= arr.Length; currentPosition++)
        {
            int firstPosition = currentPosition - query;
            int dequeuedPosition = firstPosition - 1;

            if (arr[dequeuedPosition] >= response)
            {
                response = Math.Min(response, arr.Skip(firstPosition).Take(query).Max());
            }
        }

        return response;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;

        int[] queries = new int[q];

        for (int queriesItr = 0; queriesItr < q; queriesItr++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[] result = solve(arr, queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
