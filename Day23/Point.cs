using System;
using System.Globalization;

namespace Day23
{
    internal struct Point
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public int GetDistanceTo(Point other)
        {
            return Math.Abs(X - other.X)
                   + Math.Abs(Y - other.Y)
                   + Math.Abs(Z - other.Z);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", X, Y, Z);
        }
    }
}
