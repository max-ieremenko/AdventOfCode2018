using System;
using System.Diagnostics;

namespace Day06
{
    [DebuggerDisplay("{OccupiedBy.Id}")]
    internal sealed class AreaMarker
    {
        private int? _distanceToCenter;

        public AreaMarker(Location center, bool onEdge)
        {
            Center = center;
            OnEdge = onEdge;
        }

        public Location Center { get; }

        public bool OnEdge { get; }

        public Area OccupiedBy { get; private set; }

        public bool IsShared { get; private set; }

        public void TryToOccupy(Area area)
        {
            var distance = area.GetDistanceTo(Center);
            if (!_distanceToCenter.HasValue || distance < _distanceToCenter)
            {
                if (distance == 0 && _distanceToCenter == 0)
                {
                    throw new InvalidOperationException();
                }

                _distanceToCenter = distance;
                OccupiedBy = area;
                IsShared = false;
            }
            else if (distance == _distanceToCenter)
            {
                IsShared = true;
            }
        }
    }
}
