using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var two = 0;
            var three = 0;

            foreach (var line in input)
            {
                var counter = GetCounters(line);
                if (counter.Two)
                {
                    two++;
                }

                if (counter.Three)
                {
                    three++;
                }
            }

            return two * three;
        }

        internal static Counter GetCounters(string input)
        {
            var counters = input
                .GroupBy(i => i)
                .Select(i => i.Count())
                .Where(i => i >= 2 && i <= 3);

            var two = false;
            var three = false;
            foreach (var item in counters)
            {
                if (item == 2)
                {
                    two = true;
                }
                else
                {
                    three = true;
                }
            }

            return new Counter(two, three);
        }
    }
}
