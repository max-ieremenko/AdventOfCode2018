using System;
using System.Diagnostics;

namespace Day23
{
    [DebuggerDisplay("{Location.X},{Location.Y},{Location.Z} - {Radius}")]
    internal struct Nanobot : IEquatable<Nanobot>
    {
        public Nanobot(Point location, int radius)
        {
            Location = location;
            Radius = radius;
        }

        public Point Location { get; }

        public int Radius { get; }

        public bool Equals(Nanobot other)
        {
            return Location.Equals(other.Location) && Radius == other.Radius;
        }

        public override bool Equals(object obj)
        {
            return obj is Nanobot other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode();
        }

        public bool InRange(Point point)
        {
            var distance = Location.GetDistanceTo(point);
            return distance <= Radius;
        }
    }
}