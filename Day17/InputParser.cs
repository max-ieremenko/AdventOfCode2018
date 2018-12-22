using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Day17
{
    internal static class InputParser
    {
        public static Map Parse(IEnumerable<string> input)
        {
            var groundByCoordinate = new Dictionary<Point, GroundType>();
            foreach (var line in input)
            {
                // x=495, y=2..7
                // y=13, x=498..504
                var commaIndex = line.IndexOf(',');

                var index = line.IndexOf('=');
                var value1 = int.Parse(line.Substring(index + 1, commaIndex - index - 1), CultureInfo.InvariantCulture);

                index = line.IndexOf('=', commaIndex);
                var value2 = line
                    .Substring(index + 1)
                    .Split(new[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                    .ToArray();

                var isX = line.StartsWith("x");
                for (var i = value2[0]; i <= value2[1]; i++)
                {
                    var location = isX ? new Point(value1, i) : new Point(i, value1);
                    groundByCoordinate[location] = GroundType.Clay;
                }
            }

            return new Map(groundByCoordinate);
        }

        public static Point Right(this Point location)
        {
            return new Point(location.X + 1, location.Y);
        }

        public static Point Left(this Point location)
        {
            return new Point(location.X - 1, location.Y);
        }

        public static Point Up(this Point location)
        {
            return new Point(location.X, location.Y - 1);
        }

        public static Point Down(this Point location)
        {
            return new Point(location.X, location.Y + 1);
        }

        public static Point Move(this Point location, FlowDirection direction)
        {
            switch (direction)
            {
                case FlowDirection.Down:
                    return Down(location);

                case FlowDirection.Up:
                    return Up(location);

                case FlowDirection.Left:
                    return Left(location);

                case FlowDirection.Right:
                    return Right(location);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
