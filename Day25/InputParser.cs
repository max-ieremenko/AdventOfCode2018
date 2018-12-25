using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day25
{
    internal static class InputParser
    {
        public static IList<Point> Parse(IEnumerable<string> input)
        {
            var result = new List<Point>();
            foreach (var line in input)
            {
                var values = line
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                    .ToArray();

                result.Add(new Point(values[0], values[1], values[2], values[3]));
            }

            return result;
        }
    }
}
