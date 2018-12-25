using System.Collections.Generic;

namespace Day25
{
    internal sealed class Constellation
    {
        private readonly HashSet<Point> _points;

        public Constellation(Point point)
        {
            _points = new HashSet<Point> { point };
        }

        public bool Join(Point point)
        {
            foreach (var other in _points)
            {
                if (point.GetDistanceTo(other) <= 3)
                {
                    _points.Add(point);
                    return true;
                }
            }

            return false;
        }

        public void UnionWith(Constellation constellation)
        {
            _points.UnionWith(constellation._points);
        }
    }
}
