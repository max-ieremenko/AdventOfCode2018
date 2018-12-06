using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public static class Task2
    {
        public static int Solve(IEnumerable<string> input, int lessThen)
        {
            var areas = input
                .Select((definition, id) => new Area(id, new Location(definition)))
                .ToList();

            var district = new District(areas.Select(i => i.Center));

            var result = 0;
            foreach (var marker in district.GetMarkers())
            {
                var totalDistance = areas.Select(i => i.GetDistanceTo(marker.Center)).Sum();
                if (totalDistance < lessThen)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
