using System;
using System.Diagnostics;

namespace Day6
{
    [DebuggerDisplay("{Id} center {Center.X}, {Center.Y}")]
    internal struct Area : IEquatable<Area>
    {
        public Area(int id, Location center)
        {
            Id = ((char)('A' + id)).ToString();
            Center = center;
        }

        public string Id { get; }

        public Location Center { get; }

        public int GetDistanceTo(Location location)
        {
            return Math.Abs(location.X - Center.X) + Math.Abs(location.Y - Center.Y);
        }

        public bool Equals(Area other)
        {
            return string.Equals(Id, other.Id, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return obj is Area other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Id);
        }
    }
}
