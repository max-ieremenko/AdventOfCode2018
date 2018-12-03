using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day1
{
    public static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var list = input
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var frequency = 0;
            var results = new HashSet<int> { 0 };

            while (true)
            {
                foreach (var i in list)
                {
                    frequency += i;
                    if (!results.Add(frequency))
                    {
                        return frequency;
                    }
                }
            }
        }
    }
}
