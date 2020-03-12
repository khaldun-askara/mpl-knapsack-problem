using System;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolver slv = new MySuperSolver();
            Console.WriteLine(slv.GetName() + ":");
            var ms = new int[2];
            ms[0] = 14;
            var cs = new int[2];
            bool[] answer = slv.Solve(10, ms, cs);
            Console.WriteLine(answer[0]);
        }
    }
}
