using System;
using System.Diagnostics;
using System.IO;

namespace Day05
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task1.Solve(File.ReadAllText("input1.txt")));
                Console.WriteLine("Part two: {0}", Task2.Solve(File.ReadAllText("input2.txt")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("...");
                Console.ReadLine();
            }
        }
    }
}
