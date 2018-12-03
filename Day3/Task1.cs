using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            return input
                .Select(i => new Claim(i))
                .SelectMany(i => i.GetTiles())
                .GroupBy(i => i)
                .Count(i => i.Count() > 1);
        }
    }
}
