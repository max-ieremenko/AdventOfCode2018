using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal static class Parser
    {
        public static IList<Step> Parse(IEnumerable<string> input)
        {
            var stepByName = new Dictionary<string, Step>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in input)
            {
                var pair = ParseLine(line);

                if (!stepByName.ContainsKey(pair.Key))
                {
                    stepByName.Add(pair.Key, new Step(pair.Key));
                }

                if (!stepByName.ContainsKey(pair.Value))
                {
                    stepByName.Add(pair.Value, new Step(pair.Value));
                }

                stepByName[pair.Value].DependsOn.Add(pair.Key);
            }

            return stepByName.Values.OrderBy(i => i.Name).ToList();
        }

        private static KeyValuePair<string, string> ParseLine(string line)
        {
            // Step C must be finished before step A can begin.
            var parts = line.Split(' ');
            return new KeyValuePair<string, string>(parts[1], parts[7]);
        }
    }
}
