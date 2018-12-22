using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day17
{
    internal sealed class Map
    {
        private readonly Dictionary<Point, GroundType> _groundByCoordinate;

        public Map(Dictionary<Point, GroundType> groundByCoordinate)
        {
            _groundByCoordinate = groundByCoordinate;

            LeftTop = Spring;
            RightBottom = _groundByCoordinate.Keys.First();

            foreach (var location in _groundByCoordinate.Keys)
            {
                LeftTop = new Point(Math.Min(LeftTop.X, location.X), Math.Min(LeftTop.Y, location.Y));
                RightBottom = new Point(Math.Max(RightBottom.X, location.X), Math.Max(RightBottom.Y, location.Y));
            }

            LeftTop = LeftTop.Left();
            RightBottom = RightBottom.Right();
        }

        public Point Spring => new Point(500, 0);

        public Point LeftTop { get; }

        public Point RightBottom { get; }

        public GroundType this[Point location]
        {
            get
            {
                if (location == Spring)
                {
                    return GroundType.Water;
                }

                if (!_groundByCoordinate.TryGetValue(location, out var type))
                {
                    return GroundType.Sand;
                }

                return type;
            }

            set
            {
                if (value != GroundType.Water || this[location] == GroundType.Clay)
                {
                    throw new NotSupportedException();
                }

                _groundByCoordinate[location] = value;
            }
        }

        public int GetCellsNumberWithWater()
        {
            return _groundByCoordinate.Count(i => i.Value == GroundType.Water && i.Key != Spring);
        }

        public override string ToString()
        {
            var text = new StringBuilder();

            text.Append("   ");
            for (var x = LeftTop.X; x <= RightBottom.X; x++)
            {
                text.Append(x.ToString().Last());
            }

            for (var y = LeftTop.Y; y <= RightBottom.Y; y++)
            {
                text.AppendLine();

                text.Append(y.ToString("00")).Append(" ");
                for (var x = LeftTop.X; x <= RightBottom.X; x++)
                {
                    var location = new Point(x, y);
                    var value = (char)this[location];
                    if (location == Spring)
                    {
                        value = (char)GroundType.Spring;
                    }

                    text.Append(value);
                }
            }

            return text.ToString();
        }
    }
}