using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var areas = input
                .Select((definition, id) => new Area(id, new Location(definition)))
                .ToList();

            var district = new District(areas.Select(i => i.Center));

            foreach (var area in areas)
            {
                foreach (var marker in district.GetMarkers())
                {
                    marker.TryToOccupy(area);
                }
            }

            var sizeByArea = new Dictionary<Area, int>();
            foreach (var marker in district.GetMarkers().Where(i => !i.IsShared))
            {
                if (marker.OnEdge)
                {
                    sizeByArea[marker.OccupiedBy] = -1;
                }
                else
                {
                    sizeByArea.TryGetValue(marker.OccupiedBy, out var size);
                    if (size >= 0)
                    {
                        size++;
                        sizeByArea[marker.OccupiedBy] = size;
                    }
                }
            }

            return sizeByArea.Values.OrderByDescending(i => i).First();
        }
    }
}
