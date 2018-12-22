using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Day15
{
    internal partial class PathResolver
    {
        private sealed class Vertex
        {
            private readonly int _destinationLength;

            public Vertex(Point location, Point destination, Vertex previous)
            {
                Location = location;
                Previous = previous;
                _destinationLength = Math.Abs(location.X - destination.X) + Math.Abs(location.Y - destination.Y);

                UpdateLength();
            }

            public int Length { get; private set; }

            public int EstimatedDestinationLength { get; private set; }

            public Point Location { get; }

            public Vertex Previous { get; private set; }

            public bool IsSealed { get; set; }

            public void TryOtherPrevious(Vertex candidate)
            {
                if (ComparePrevious(candidate))
                {
                    Previous = candidate;
                    UpdateLength();
                }
            }

            public Direction GetDirection()
            {
                return new Direction(GetFirstStepLocation(), Location, Length);
            }

            public override string ToString()
            {
                var list = new List<Point>();

                var current = this;
                while (current != null)
                {
                    list.Insert(0, current.Location);
                    current = current.Previous;
                }

                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} ({1}): {2}",
                    Length,
                    EstimatedDestinationLength,
                    string.Join(" => ", list.Select(i => string.Format(CultureInfo.InvariantCulture, "{0},{1}", i.X, i.Y))));
            }

            private Point GetFirstStepLocation()
            {
                if (Previous.Previous == null)
                {
                    return Location;
                }

                return Previous.GetFirstStepLocation();
            }

            private void UpdateLength()
            {
                Length = Previous?.Length + 1 ?? 0;
                EstimatedDestinationLength = Length + _destinationLength;
            }

            private bool ComparePrevious(Vertex candidate)
            {
                if (candidate.Length > Previous.Length)
                {
                    return false;
                }

                if (candidate.Length < Previous.Length)
                {
                    return true;
                }

                return candidate.GetFirstStepLocation().CompareInReadingOrder(GetFirstStepLocation()) < 0;
            }
        }
    }
}
