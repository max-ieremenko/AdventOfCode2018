using System.Collections.Generic;

namespace Day18
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var map = InputParser.Parse(input);

            for (var i = 0; i < 10; i++)
            {
                map.NextMinute();
            }

            return map.GetResourceValue();
        }
    }
}
