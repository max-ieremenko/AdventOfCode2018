using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Day03
{
    [DebuggerDisplay("{Left},{Top}: {With}x{Height}")]
    internal struct Claim
    {
        public Claim(string definition)
        {
            // "#1 @ 1,3: 4x4"
            var index1 = definition.IndexOf("@");
            var index2 = definition.IndexOf(":", index1);

            Id = definition.Substring(1, index1 - 1).Trim();

            var position = definition
                .Substring(index1 + 1, index2 - index1 - 1)
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            Left = position[0];
            Top = position[1];

            position = definition
                .Substring(index2 + 1)
                .Split(new[] { 'x' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            With = position[0];
            Height = position[1];
        }

        public int Left { get; }

        public int Top { get; }

        public int With { get; }

        public int Height { get; }

        public string Id { get; }

        public IEnumerable<Tile> GetTiles()
        {
            for (var x = 0; x < With; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    yield return new Tile(Left + x, Top + y);
                }
            }
        }
    }
}