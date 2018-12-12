using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day12
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task.Solve(ReadFile("input.txt"), 20));
                Console.WriteLine("Part two: {0}", Task.Solve(ReadFile("input.txt"), 50000000000));
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
