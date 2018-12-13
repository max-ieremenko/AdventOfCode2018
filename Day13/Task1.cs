using System.Collections.Generic;
using System.Globalization;

namespace Day13
{
    internal static class Task1
    {
        public static string Solve(IEnumerable<string> input)
        {
            var track = InputParser.ParseTrack(input);

            IList<Cart> crash;
            while ((crash = track.Tick()).Count == 0)
            {
            }

            var crashLocation = crash[0].Location;
            return string.Format(CultureInfo.InvariantCulture, "{0},{1}", crashLocation.X, crashLocation.Y);
        }
    }
}
