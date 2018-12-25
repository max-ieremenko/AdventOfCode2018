using System.Diagnostics;

namespace Day23
{
    [DebuggerDisplay("{Location.X},{Location.Y},{Location.Z} - {Radius}")]
    internal struct Nanobot
    {
        public Nanobot(Point location, int radius)
        {
            Location = location;
            Radius = radius;
        }

        public Point Location { get; }

        public int Radius { get; }
    }
}