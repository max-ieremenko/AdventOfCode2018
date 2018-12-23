using System;
using System.Diagnostics;
using System.Drawing;

namespace Day22
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task1.Solve(11991, new Point(6, 797)));
                Console.WriteLine("Part two: {0}", Task2.Solve(11991, new Point(6, 797)));
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
