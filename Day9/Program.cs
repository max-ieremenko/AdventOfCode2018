using System;
using System.Diagnostics;

namespace Day9
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Part one: {0}", Task.Solve(464, 71730));
                Console.WriteLine("Part two: {0}", Task.Solve(464, 71730 * 100));
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
