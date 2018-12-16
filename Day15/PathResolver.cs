using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day15
{
    internal sealed partial class PathResolver
    {
        private readonly bool[,] _field;
        private readonly ICollection<Point> _unitLocations;
        private readonly int _fieldWidth;
        private readonly int _fieldHeight;

        public PathResolver(bool[,] field, IEnumerable<Point> unitLocations)
        {
            _field = field;
            _fieldWidth = field.GetLength(0);
            _fieldHeight = field.GetLength(1);
            _unitLocations = new HashSet<Point>(unitLocations);
        }

        public static int ComparePointsInReadingOrder(Point x, Point y)
        {
            var c = x.Y.CompareTo(y.Y);
            if (c == 0)
            {
                c = x.X.CompareTo(y.X);
            }

            return c;
        }

        public Direction FindPath(Point from, Point to)
        {
            return ResolveAllPaths(from, to)
                .Select(i => new Direction(i.FirstStep, i.Length))
                .OrderBy(i => i.Length)
                .ThenBy(i => i.FirstStep.Y)
                .ThenBy(i => i.FirstStep.X)
                .FirstOrDefault();
        }

        private IEnumerable<Step> ResolveAllPaths(Point from, Point to)
        {
            var start = new Step(from, to);
            var queue = new Dictionary<Point, Step>();
            queue.Add(start.Location, start);

            var lastPathLength = 0;

            while (queue.Count > 0)
            {
                var current = queue.Values.OrderBy(i => i.EstimatedDestinationLength).First();
                queue.Remove(current.Location);

                if (current.Location == to)
                {
                    if (lastPathLength == 0)
                    {
                        lastPathLength = current.Length;
                    }

                    yield return current;

                    if (current.Length > lastPathLength)
                    {
                        yield break;
                    }
                }
                else
                {
                    foreach (var nextLocation in GetNeighborLocations(current.Location).Where(i => i == to || CanBeOccupied(i)))
                    {
                        if (current.IsVisited(nextLocation))
                        {
                            continue;
                        }

                        var next = current.Next(nextLocation);

                        if (queue.TryGetValue(nextLocation, out var existing))
                        {
                            if (existing.Length > next.Length)
                            {
                                queue.Remove(nextLocation);
                                queue.Add(next.Location, next);
                            }
                            else if (existing.Length == next.Length)
                            {
                                var existingFirstStep = existing.FirstStep;
                                var nextFirstStep = next.FirstStep;
                                if (ComparePointsInReadingOrder(existingFirstStep, nextFirstStep) > 0)
                                {
                                    queue.Remove(nextLocation);
                                    queue.Add(next.Location, next);
                                }
                            }
                        }
                        else
                        {
                            queue.Add(next.Location, next);
                        }
                    }
                }
            }
        }

        private bool CanBeOccupied(Point location)
        {
            if (location.X < 0 || location.X >= _fieldWidth || location.Y < 0 || location.Y >= _fieldHeight)
            {
                return false;
            }

            if (!_field[location.X, location.Y])
            {
                return false;
            }

            return !_unitLocations.Contains(location);
        }

        private IEnumerable<Point> GetNeighborLocations(Point location)
        {
            yield return new Point(location.X - 1, location.Y);
            yield return new Point(location.X + 1, location.Y);
            yield return new Point(location.X, location.Y - 1);
            yield return new Point(location.X, location.Y + 1);
        }
    }
}
