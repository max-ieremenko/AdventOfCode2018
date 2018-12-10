using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Day10
{
    public sealed class Star
    {
        public Star(string definition)
        {
            // position=<-3,  6> velocity=< 2, -1>
            var startIndex = definition.IndexOf('<');
            var endIndex = definition.IndexOf('>', startIndex);
            var numbers = definition
                .Substring(startIndex + 1, endIndex - startIndex - 1)
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            Location = new Point(numbers[0], numbers[1]);

            startIndex = definition.IndexOf('<', endIndex);
            endIndex = definition.IndexOf('>', startIndex);
            numbers = definition
                .Substring(startIndex + 1, endIndex - startIndex - 1)
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            Vector = new Size(numbers[0], numbers[1]);
        }

        public Point Location { get; private set; }

        public Size Vector { get; }

        public void MoveForward()
        {
            Location += Vector;
        }

        public void MoveBack()
        {
            Location -= Vector;
        }
    }
}