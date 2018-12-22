using System;
using System.Diagnostics;
using System.Drawing;

namespace Day17
{
    [DebuggerDisplay("{StartOn.X},{StartOn.Y} {Direction}")]
    internal sealed class SpringStep
    {
        public SpringStep(Point startOn, FlowDirection direction, int length, Point downEntryPoint)
        {
            StartOn = startOn;
            Direction = direction;
            Length = length;
            DownEntryPoint = downEntryPoint;
        }

        public Point StartOn { get; }

        public FlowDirection Direction { get; }

        public int Length { get; }

        public Point DownEntryPoint { get; }
    }
}