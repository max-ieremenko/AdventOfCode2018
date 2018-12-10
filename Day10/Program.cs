using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day10
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                var task = new Task();
                task.Solve(ReadFile("input.txt"));

                Console.WriteLine("Part one:");
                Console.WriteLine(task.GetMessage());
                Console.WriteLine("Part two: {0}", task.WaitTime);
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
