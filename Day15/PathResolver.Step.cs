using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Day15
{
    internal partial class PathResolver
    {
        [DebuggerDisplay("{Length}")]
        private sealed class Step
        {
            private ICollection<Point> _visited;

            public Step(Point location, Point destination)
                : this(location, destination, new HashSet<Point> { location })
            {
            }

            private Step(Point location, Point destination, ICollection<Point> visited)
            {
                Location = location;
                Destination = destination;
                EstimatedDestinationLength = Math.Abs(location.X - destination.X) + Math.Abs(location.Y - destination.Y);

                _visited = visited;
            }

            public Point Location { get; }

            public Point Destination { get; }

            public int Length { get; private set; }

            public int EstimatedDestinationLength { get; private set; }

            public Point FirstStep { get; private set; }

            public Step Next(Point location)
            {
                _visited.Add(location);

                var next = new Step(location, Destination, _visited);

                next.Length = Length + 1;
                next.EstimatedDestinationLength += next.Length;

                next.FirstStep = Length == 0 ? location : FirstStep;

                return next;
            }

            public bool IsVisited(Point location)
            {
                return _visited.Contains(location);
            }
        }
    }
}
