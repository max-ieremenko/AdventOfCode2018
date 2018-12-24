using System;
using System.Globalization;

namespace Day23
{
    internal struct Point : IEquatable<Point>
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

        public bool Equals(Point other)
        {
            return X == other.X
                   && Y == other.Y
                   && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(CombineHashCodes(X, Y), Z);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", X, Y, Z);
        }

        private static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }
    }
}
