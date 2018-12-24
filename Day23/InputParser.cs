using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day23
{
    internal static class InputParser
    {
        public static IList<Nanobot> Parse(IEnumerable<string> input)
        {
            var result = new List<Nanobot>();
            foreach (var line in input)
            {
                // pos=<0,0,0>, r=4
                var index1 = line.IndexOf('<');
                var index2 = line.IndexOf('>', index1);

                var coordinates = line.Substring(index1 + 1, index2 - index1 - 1)
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                    .ToArray();

                index1 = line.IndexOf('=', index2);
                var radius = int.Parse(line.Substring(index1 + 1), CultureInfo.InvariantCulture);

                result.Add(new Nanobot(new Point(coordinates[0], coordinates[1], coordinates[2]), radius));
            }

            return result;
        }
    }
}
