using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day22
{
    internal sealed class CaveSystem
    {
        private const int MagicNumber = 20183;

        private readonly IDictionary<Point, int> _erosionLevelByCave;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        public CaveSystem(int depth, Point target)
        {
            Depth = depth;
            Target = target;

            _erosionLevelByCave = new Dictionary<Point, int>((target.X + 1) * (target.Y + 1));

            var maxLength = Math.Max(target.X, target.Y);
            _maxWidth = target.X + maxLength;
            _maxHeight = target.Y + maxLength;
        }

        public int Depth { get; }

        public Point Target { get; }

        public RegionType GetCaveType(Point cave)
        {
            if (cave == new Point(0, 0) || cave == Target)
            {
                return RegionType.Rocky;
            }

            var erosionLevel = GetErosionLevel(cave);
            var type = erosionLevel % 3;

            return (RegionType)type;
        }

        public IEnumerable<Tool> GetGaveAvailableTools(Point cave)
        {
            if (cave == new Point(0, 0))
            {
                return new[] { Tool.Torch };
            }

            var type = GetCaveType(cave);
            switch (type)
            {
                case RegionType.Rocky:
                    return new[] { Tool.ClimbingGear, Tool.Torch };

                case RegionType.Wet:
                    return new[] { Tool.ClimbingGear, Tool.Neither };

                case RegionType.Narrow:
                    return new[] { Tool.Torch, Tool.Neither };

                default:
                    throw new NotSupportedException();
            }
        }

        public bool WithingSystem(Point cave)
        {
            return cave.X >= 0
                   && cave.Y >= 0
                   && cave.X <= _maxWidth
                   && cave.Y <= _maxHeight;
        }

        private int GetErosionLevel(Point cave)
        {
            if (!_erosionLevelByCave.TryGetValue(cave, out var result))
            {
                result = CalculateErosionLevel(cave);
                _erosionLevelByCave.Add(cave, result);
            }

            return result;
        }

        private int CalculateErosionLevel(Point cave)
        {
            var index = GetGeologicIndex(cave);
            var result = (index + Depth) % MagicNumber;

            return (int)result;
        }

        private long GetGeologicIndex(Point cave)
        {
            if (cave == new Point(0, 0) || cave == Target)
            {
                return 0;
            }

            if (cave.Y == 0)
            {
                return cave.X * 16807;
            }

            if (cave.X == 0)
            {
                return cave.Y * 48271;
            }

            var a = GetErosionLevel(new Point(cave.X - 1, cave.Y));
            var b = GetErosionLevel(new Point(cave.X, cave.Y - 1));
            return a * b;
        }
    }
}
