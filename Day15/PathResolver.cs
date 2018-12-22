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

        public Direction FindPath(Point from, IEnumerable<Point> targets)
        {
            return targets
                .SelectMany(GetNeighborLocations)
                .Where(CanBeOccupied)
                .Distinct()
                .AsParallel()
                .Select(i => ResolvePath(from, i))
                .Where(i => i != null)
                .OrderByReadingOrder()
                .FirstOrDefault();
        }

        private Direction ResolvePath(Point from, Point to)
        {
            var initial = new Vertex(from, to, null);
            var vertexByLocation = new Dictionary<Point, Vertex>
            {
                { initial.Location, initial }
            };
            var queue = new List<Vertex> { initial };

            while (queue.Count > 0)
            {
                queue.Sort((x, y) =>
                {
                    var c = x.EstimatedDestinationLength.CompareTo(y.EstimatedDestinationLength);
                    if (c == 0)
                    {
                        c = x.Location.CompareInReadingOrder(y.Location);
                    }

                    return c;
                });

                var current = queue[0];
                queue.RemoveAt(0);
                current.IsSealed = true;

                if (current.Location == to)
                {
                    return current.GetDirection();
                }

                foreach (var nextLocation in GetNeighborLocations(current.Location).Where(CanBeOccupied))
                {
                    if (!vertexByLocation.TryGetValue(nextLocation, out var next))
                    {
                        next = new Vertex(nextLocation, to, current);
                        vertexByLocation.Add(nextLocation, next);
                        queue.Add(next);
                    }
                    else if (!next.IsSealed)
                    {
                        next.TryOtherPrevious(current);
                    }
                }
            }

            return null;
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
            yield return new Point(location.X, location.Y - 1);
            yield return new Point(location.X - 1, location.Y);
            yield return new Point(location.X + 1, location.Y);
            yield return new Point(location.X, location.Y + 1);
        }
    }
}
