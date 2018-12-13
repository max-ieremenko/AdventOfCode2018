using System;
using System.Collections.Generic;
using System.Globalization;

namespace Day13
{
    internal static class Task2
    {
        public static string Solve(IEnumerable<string> input)
        {
            var track = InputParser.ParseTrack(input);

            while (track.Carts.Count > 1)
            {
                track.Tick();
            }

            if (track.Carts.Count == 0)
            {
                throw new NotSupportedException();
            }

            var lastLocation = track.Carts[0].Location;
            return string.Format(CultureInfo.InvariantCulture, "{0},{1}", lastLocation.X, lastLocation.Y);
        }
    }
}
