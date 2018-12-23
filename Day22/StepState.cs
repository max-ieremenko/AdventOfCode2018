using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace Day22
{
    [DebuggerDisplay("{Location.X},{Location.Y} {Tool}")]
    internal struct StepState : IEquatable<StepState>
    {
        public StepState(Point location, Tool tool)
        {
            Location = location;
            Tool = tool;
        }

        public Point Location { get; }

        public Tool Tool { get; }

        public bool Equals(StepState other)
        {
            return Location == other.Location
                   && Tool == other.Tool;
        }

        public override bool Equals(object obj)
        {
            return obj is StepState step && Equals(step);
        }

        public override int GetHashCode()
        {
            var h1 = Location.GetHashCode();
            var h2 = Tool.GetHashCode();
            return (h1 << 5) + h1 ^ h2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1} {2}", Location.X, Location.Y, Tool);
        }
    }
}
