using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day24
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task1.Solve(ReadFile("input.txt")));
                Console.WriteLine("Part two: {0}", Task2.Solve(ReadFile("input.txt")));
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

        private static IEnumerable<string> ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
