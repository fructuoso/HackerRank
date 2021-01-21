using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

struct Node
{
    public int Data { get; set; }
    public int Depth { get; set; }

    public Node(int data, int depth = 0)
    {
        Data = data;
        Depth = depth;
    }
}

class Solution
{

    static IEnumerable<int> GetDividers(int n)
    {

        for (int i = (int)Math.Sqrt(n); i >= 2; i--)
        {
            if (n % i == 0) yield return i;
        }
    }

    /*
     * Complete the downToZero function below.
     */
    static int downToZero(int n)
    {
        var queue = new Queue<Node>();

        queue.Enqueue(new Node(n));

        while (queue.Any())
        {
            Node currentNode = queue.Dequeue();

            if (currentNode.Data == 4)
            {
                currentNode.Depth += 3;
                return currentNode.Depth;
            }
            else if (currentNode.Data < 4)
            {
                currentNode.Depth += currentNode.Data;
                return currentNode.Depth;
            }

            queue.Enqueue(new Node(currentNode.Data - 1, currentNode.Depth + 1));

            GetDividers(currentNode.Data).ToList().ForEach(data => {
                int maxDividers = Math.Max(data, currentNode.Data / data);
                queue.Enqueue(new Node(maxDividers, currentNode.Depth + 1));
            });
        }

        return 0;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int result = downToZero(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
