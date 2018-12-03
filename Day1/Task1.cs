using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day1
{
    public static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var result = 0;
            foreach (var i in input.Select(i => int.Parse(i, CultureInfo.InvariantCulture)))
            {
                result += i;
            }

            return result;
        }
    }
}
