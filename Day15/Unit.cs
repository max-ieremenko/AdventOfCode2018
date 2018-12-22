using System;
using System.Diagnostics;
using System.Drawing;

namespace Day15
{
    [DebuggerDisplay("{Flag} on {Location.X},{Location.Y} HP {HitPoints}")]
    internal sealed class Unit
    {
        public const int DefaultAttackPower = 3;

        public Unit(char flag, Point initialLocation)
        {
            Flag = flag;
            Location = initialLocation;

            HitPoints = 200;
            AttackPower = DefaultAttackPower;
        }

        public char Flag { get; }

        public Point Location { get; set; }

        public int AttackPower { get; set; }

        public int HitPoints { get; set; }

        public bool IsNeighborOf(Point location)
        {
            return (Location.X == location.X && Math.Abs(Location.Y - location.Y) == 1)
                   || (Location.Y == location.Y && Math.Abs(Location.X - location.X) == 1);
        }

        public Unit Clone()
        {
            return new Unit(Flag, Location);
        }
    }
}
