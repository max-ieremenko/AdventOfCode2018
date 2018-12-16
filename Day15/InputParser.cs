using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day15
{
    internal static class InputParser
    {
        public static Map Parse(IEnumerable<string> input)
        {
            var map = new List<bool[]>();
            var units = new List<Unit>();

            foreach (var line in input)
            {
                ParseLine(line, map, units);
            }

            var field = new bool[map[0].Length, map.Count];
            for (var y = 0; y < map.Count; y++)
            {
                var line = map[y];
                for (var x = 0; x < line.Length; x++)
                {
                    field[x, y] = line[x];
                }
            }

            return new Map(field, units);
        }

        private static void ParseLine(string line, IList<bool[]> map, IList<Unit> units)
        {
            var row = new bool[line.Length];
            map.Add(row);

            for (var i = 0; i < line.Length; i++)
            {
                var cell = line[i];
                switch ((Area)cell)
                {
                    case Area.Cavern:
                        row[i] = true;
                        break;

                    case Area.Wall:
                        row[i] = false;
                        break;

                    case Area.Elf:
                    case Area.Goblin:
                        row[i] = true;
                        units.Add(new Unit(cell, new Point(i, map.Count - 1)));
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}
