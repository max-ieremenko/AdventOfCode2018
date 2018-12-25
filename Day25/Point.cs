using System;

namespace Day25
{
    internal struct Point : IEquatable<Point>
    {
        public Point(int x, int y, int z, int t)
        {
            X = x;
            Y = y;
            Z = z;
            T = t;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public int T { get; }

        public int GetDistanceTo(Point other)
        {
            return Math.Abs(X - other.X)
                   + Math.Abs(Y - other.Y)
                   + Math.Abs(Z - other.Z)
                   + Math.Abs(T - other.T);
        }

        public bool Equals(Point other)
        {
            return X == other.X
                   && Y == other.Y
                   && Z == other.Z
                   && T == other.T;
        }

        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(X, CombineHashCodes(Y, CombineHashCodes(Z, T)));
        }

        private static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }
    }
}