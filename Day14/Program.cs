﻿using System;
using System.Diagnostics;

namespace Day14
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task1.Solve(824501));
                Console.WriteLine("Part two: {0}", Task2.Solve("824501"));
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
