using System.Diagnostics;
using System.Drawing;

namespace Day15
{
    [DebuggerDisplay("{FirstStep.X},{FirstStep.Y} => {Length}")]
    internal sealed class Direction
    {
        public Direction(Point firstStep, Point destination, int length)
        {
            FirstStep = firstStep;
            Destination = destination;
            Length = length;
        }

        public Point FirstStep { get; }

        public Point Destination { get; }

        public int Length { get; }
    }
}
