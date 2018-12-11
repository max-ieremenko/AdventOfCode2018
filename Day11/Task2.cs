using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Day11
{
    internal static class Task2
    {
        public static string Solve(int input)
        {
            var grid = new Grid(input);

            var answer = GetPoints(grid)
                .AsParallel()
                .Select(i =>
                {
                    var pointMaxPower = grid.GetCellMaxPowerLevel(i.X, i.Y);
                    return new
                    {
                        Location = i,
                        Power = pointMaxPower.Key,
                        Size = pointMaxPower.Value
                    };
                })
                .OrderByDescending(i => i.Power)
                .First();

            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", answer.Location.X, answer.Location.Y, answer.Size);
        }

        private static IEnumerable<Point> GetPoints(Grid grid)
        {
            for (var x = 1; x <= grid.Size; x++)
            {
                for (var y = 1; y <= grid.Size; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
}
