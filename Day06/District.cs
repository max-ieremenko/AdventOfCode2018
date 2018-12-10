using System;
using System.Collections.Generic;

namespace Day06
{
    internal sealed class District
    {
        private readonly IList<AreaMarker> _grid;

        public District(IEnumerable<Location> areaCenters)
        {
            var counter = 0;
            foreach (var center in areaCenters)
            {
                counter++;
                if (counter == 1)
                {
                    LeftTop = center;
                    RightBottom = center;
                }
                else
                {
                    LeftTop = new Location(Math.Min(LeftTop.X, center.X), Math.Min(LeftTop.Y, center.Y));
                    RightBottom = new Location(Math.Max(RightBottom.X, center.X), Math.Max(RightBottom.Y, center.Y));
                }
            }

            _grid = new List<AreaMarker>();
            for (var x = LeftTop.X; x <= RightBottom.X; x++)
            {
                for (var y = LeftTop.Y; y <= RightBottom.Y; y++)
                {
                    _grid.Add(new AreaMarker(
                        new Location(x, y),
                        x == LeftTop.X || x == RightBottom.X || y == LeftTop.Y || y == RightBottom.Y));
                }
            }
        }

        public Location LeftTop { get; }

        public Location RightBottom { get; }

        public IEnumerable<AreaMarker> GetMarkers()
        {
            return _grid;
        }
    }
}
