using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal static class InputParser
    {
        private const char ContainsPlant = '#';

        public static Tunnel Parse(IEnumerable<string> input)
        {
            bool[] initialState = null;
            var notes = new List<SpreadNote>();

            var rowIndex = 0;
            foreach (var row in input)
            {
                if (rowIndex == 0)
                {
                    initialState = ParseInitialState(row.Substring("initial state: ".Length));
                }
                else if (rowIndex != 1)
                {
                    var note = ParseNote(row);
                    if (note != null)
                    {
                        notes.Add(note);
                    }
                }

                rowIndex++;
            }

            return new Tunnel(initialState, notes);
        }

        internal static bool[] ParseInitialState(string definition)
        {
            var result = new bool[definition.Length];
            for (var i = 0; i < definition.Length; i++)
            {
                result[i] = definition[i] == ContainsPlant;
            }

            return result;
        }

        internal static SpreadNote ParseNote(string definition)
        {
            // ...## => #
            if (definition.Last() == ContainsPlant)
            {
                var pattern = ParseInitialState(definition.Substring(0, 5));
                return new SpreadNote(pattern);
            }

            // ignore => .
            return null;
        }
    }
}
