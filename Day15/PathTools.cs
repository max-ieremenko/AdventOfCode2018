using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day15
{
    internal static class PathTools
    {
        public static int CompareInReadingOrder(this Point x, Point y)
        {
            var c = x.Y.CompareTo(y.Y);
            if (c == 0)
            {
                c = x.X.CompareTo(y.X);
            }

            return c;
        }

        public static IOrderedEnumerable<Direction> OrderByReadingOrder(this IEnumerable<Direction> directions)
        {
            return directions
                .OrderBy(i => i.Length)
                .ThenBy(i => i.Destination.Y)
                .ThenBy(i => i.Destination.X)
                .ThenBy(i => i.FirstStep.Y)
                .ThenBy(i => i.FirstStep.X);
        }
    }
}
