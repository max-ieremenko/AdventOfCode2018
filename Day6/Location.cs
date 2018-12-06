using System.Diagnostics;
using System.Globalization;

namespace Day6
{
    [DebuggerDisplay("{X}, {Y}")]
    public struct Location
    {
        public Location(string definition)
        {
            var index = definition.IndexOf(',');

            X = int.Parse(definition.Substring(0, index), CultureInfo.InvariantCulture);
            Y = int.Parse(definition.Substring(index + 1).Trim(), CultureInfo.InvariantCulture);
        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}