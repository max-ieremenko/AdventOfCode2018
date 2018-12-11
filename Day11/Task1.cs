using System.Drawing;
using System.Globalization;

namespace Day11
{
    internal static class Task1
    {
        public static string Solve(int input)
        {
            var grid = new Grid(input);

            var largestCell = new Point(1, 1);
            var largestCellTotalPower = int.MinValue;

            for (var x = 1; x <= grid.Size - 3; x++)
            {
                for (var y = 1; y <= grid.Size - 3; y++)
                {
                    var power = grid.GetAreaPowerLevel(x, y, 3);
                    if (power > largestCellTotalPower)
                    {
                        largestCellTotalPower = power;
                        largestCell = new Point(x, y);
                    }
                }
            }

            return string.Format(CultureInfo.InvariantCulture, "{0},{1}", largestCell.X, largestCell.Y);
        }
    }
}
