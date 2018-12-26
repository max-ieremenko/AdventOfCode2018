using System;
using System.Collections.Generic;

namespace Day18
{
    internal static class InputParser
    {
        public static Map Parse(IEnumerable<string> input)
        {
            var rows = new List<Area[]>();

            foreach (var line in input)
            {
                var row = new Area[line.Length];
                rows.Add(row);

                for (var i = 0; i < line.Length; i++)
                {
                    var cell = (Area)line[i];
                    switch (row[i] = cell)
                    {
                        case Area.Ground:
                        case Area.Tree:
                        case Area.Lumberyard:
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }

            var acres = new Area[rows[0].Length, rows.Count];
            for (var y = 0; y < acres.GetLength(1); y++)
            {
                for (var x = 0; x < acres.GetLength(0); x++)
                {
                    acres[x, y] = rows[y][x];
                }
            }

            return new Map(acres);
        }
    }
}
