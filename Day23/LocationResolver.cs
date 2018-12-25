using System;
using System.Collections.Generic;

namespace Day23
{
    internal sealed class LocationResolver
    {
        private readonly IList<Nanobot> _bots;
        private int _minX;
        private int _maxX;
        private int _minY;
        private int _maxY;
        private int _minZ;
        private int _maxZ;

        public LocationResolver(IList<Nanobot> bots)
        {
            _bots = bots;
        }

        public Point Resolve()
        {
            GetRange(i => i.Location.X, out _minX, out _maxX);
            GetRange(i => i.Location.Y, out _minY, out _maxY);
            GetRange(i => i.Location.Z, out _minZ, out _maxZ);

            var step = 1;
            while (step < Math.Abs(_maxX - _minX))
            {
                step *= 2;
            }

            Point location;
            do
            {
                location = FindBestLocation(step);
                if (step == 1)
                {
                    break;
                }

                _minX = location.X - step;
                _maxX = location.X + step;
                _minY = location.Y - step;
                _maxY = location.Y + step;
                _minZ = location.Z - step;
                _maxZ = location.Z + step;
                step /= 2;
            }
            while (true);

            return location;
        }

        private Point FindBestLocation(int step)
        {
            var bestBotsCount = 0;
            var bestDistance = 0;
            var bestLocation = default(Point);

            for (var x = _minX; x <= _maxX; x += step)
            {
                for (var y = _minY; y <= _maxY; y += step)
                {
                    for (var z = _minZ; z <= _maxZ; z += step)
                    {
                        var location = new Point(x, y, z);
                        var botsCount = 0;
                        foreach (var bot in _bots)
                        {
                            var distance = bot.Location.GetDistanceTo(location) - bot.Radius;
                            if (distance / step <= 0)
                            {
                                botsCount++;
                            }
                        }

                        if (botsCount > bestBotsCount)
                        {
                            bestBotsCount = botsCount;
                            bestDistance = location.GetDistanceTo(default(Point));
                            bestLocation = location;
                        }
                        else if (botsCount == bestBotsCount)
                        {
                            var distance = location.GetDistanceTo(default(Point));
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                bestLocation = location;
                            }
                        }
                    }
                }
            }

            return bestLocation;
        }

        private void GetRange(Func<Nanobot, int> getLocation, out int min, out int max)
        {
            min = getLocation(_bots[0]);
            max = min;

            for (var i = 1; i < _bots.Count; i++)
            {
                min = Math.Min(min, getLocation(_bots[i]));
                max = Math.Max(max, getLocation(_bots[i]));
            }
        }
    }
}
