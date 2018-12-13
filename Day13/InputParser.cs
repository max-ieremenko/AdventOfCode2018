using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day13
{
    internal static class InputParser
    {
        public static Track ParseTrack(IEnumerable<string> input)
        {
            var track = new Track();

            var row = 0;
            foreach (var line in input)
            {
                for (var column = 0; column < line.Length; column++)
                {
                    ParseCell(new Point(column, row), line[column], track);
                }

                row++;
            }

            return track;
        }

        private static void ParseCell(Point location, char cell, Track track)
        {
            switch (cell)
            {
                case (char)Path.None:
                    break;
                case (char)Path.Horizontal:
                case (char)Path.Vertical:
                case (char)Path.SlashCurve:
                case (char)Path.BackSlashCurve:
                case (char)Path.Intersection:
                    track.AddPath(location, (Path)cell);
                    break;

                case (char)CartDirection.Up:
                    track.AddPath(location, Path.Vertical);
                    track.AddCart(new Cart(location, CartDirection.Up));
                    break;
                case (char)CartDirection.Down:
                    track.AddPath(location, Path.Vertical);
                    track.AddCart(new Cart(location, CartDirection.Down));
                    break;
                case (char)CartDirection.Left:
                    track.AddPath(location, Path.Horizontal);
                    track.AddCart(new Cart(location, CartDirection.Left));
                    break;
                case (char)CartDirection.Right:
                    track.AddPath(location, Path.Horizontal);
                    track.AddCart(new Cart(location, CartDirection.Right));
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
