﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day7
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task1.Solve(ReadFile("input1.txt")));
                Console.WriteLine("Part two: {0}", Task2.Solve(ReadFile("input2.txt"), 60, 5));
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
