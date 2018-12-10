using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day10
{
    internal sealed class Sky
    {
        private readonly IList<Star> _stars;

        public Sky(IEnumerable<string> definition)
        {
            _stars = definition
                .Select(i => new Star(i))
                .ToList();
        }

        public Rectangle GetRectangle()
        {
            var leftTop = _stars[0].Location;
            var rightBottom = _stars[0].Location;

            for (var i = 1; i < _stars.Count; i++)
            {
                var point = _stars[i].Location;
                leftTop = new Point(
                    Math.Min(point.X, leftTop.X),
                    Math.Min(point.Y, leftTop.Y));
                rightBottom = new Point(
                    Math.Max(point.X, rightBottom.X),
                    Math.Max(point.Y, rightBottom.Y));
            }

            return new Rectangle(leftTop.X, leftTop.Y, rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);
        }

        public void MoveForward()
        {
            for (var i = 0; i < _stars.Count; i++)
            {
                _stars[i].MoveForward();
            }
        }

        public void MoveBack()
        {
            for (var i = 0; i < _stars.Count; i++)
            {
                _stars[i].MoveBack();
            }
        }

        public override string ToString()
        {
            var rect = GetRectangle();

            var lines = new List<char[]>();
            for (var i = 0; i <= rect.Height; i++)
            {
                var line = new char[rect.Width + 1];
                lines.Add(line);

                for (var j = 0; j < line.Length; j++)
                {
                    line[j] = '.';
                }
            }

            for (var i = 0; i < _stars.Count; i++)
            {
                var star = _stars[i];
                var row = star.Location.Y - rect.Y;
                var column = star.Location.X - rect.X;
                lines[row][column] = '#';
            }

            var output = new StringBuilder();
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                output.Append(line);

                if (i < lines.Count - 1)
                {
                    output.AppendLine();
                }
            }

            return output.ToString();
        }
    }
}
