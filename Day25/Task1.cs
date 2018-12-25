using System;
using System.Collections.Generic;

namespace Day25
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var points = InputParser.Parse(input);

            var constellations = new List<Constellation> { new Constellation(points[0]) };

            for (var i = 1; i < points.Count; i++)
            {
                var point = points[i];
                Constellation joined = null;

                for (var j = 0; j < constellations.Count; j++)
                {
                    var constellation = constellations[j];
                    if (constellation.Join(point))
                    {
                        if (joined == null)
                        {
                            joined = constellation;
                        }
                        else
                        {
                            joined.UnionWith(constellation);
                            constellations.RemoveAt(j);
                            j--;
                        }
                    }
                }

                if (joined == null)
                {
                    constellations.Add(new Constellation(point));
                }
            }

            return constellations.Count;
        }
    }
}
