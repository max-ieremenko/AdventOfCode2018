using System;
using System.Diagnostics;

namespace Day03
{
    [DebuggerDisplay("{X}x{Y}")]
    internal struct Tile : IEquatable<Tile>
    {
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public bool Equals(Tile other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Tile other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (X * 397) ^ Y;
        }
    }
}