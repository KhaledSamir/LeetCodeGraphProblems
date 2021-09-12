using System;

namespace GraphProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            DisjoinSet set = new DisjoinSet(10);
            set.Union(0, 1);
            set.Union(0, 2);
            set.Union(1, 3);

            // Console.WriteLine(set.Connected(0, 5));

            Console.WriteLine(set.Find(2));
        }
    }
}
