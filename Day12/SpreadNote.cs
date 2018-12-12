using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal sealed class SpreadNote
    {
        public SpreadNote(IList<bool> pattern, bool result)
        {
            Pattern = pattern;
            Result = result;
        }

        public IList<bool> Pattern { get; }

        public bool Result { get; }

        public IEnumerable<int> Match(IList<bool> state)
        {
            return Enumerable
                .Range(0, state.Count - Pattern.Count + 1)
                .AsParallel()
                .Where(i => IsMatch(state, Pattern, i))
                .Select(i => i + 2)
                .AsSequential();
        }

        private static bool IsMatch(IList<bool> state, IList<bool> pattern, int stateIndex)
        {
            for (var i = 0; i < pattern.Count; i++)
            {
                if (state[i + stateIndex] != pattern[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}