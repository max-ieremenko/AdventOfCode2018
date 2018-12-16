using System.Drawing;

namespace Day15
{
    internal sealed class Direction
    {
        public Direction(Point firstStep, int length)
        {
            FirstStep = firstStep;
            Length = length;
        }

        public Point FirstStep { get; }

        public int Length { get; }
    }
}
