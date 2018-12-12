using System.Collections.Generic;

namespace Day12
{
    internal sealed class SpreadNote
    {
        public SpreadNote(IList<bool> pattern)
        {
            Pattern = pattern;
        }

        public IList<bool> Pattern { get; }

        public IEnumerable<int> Match(IList<bool> state)
        {
            for (var i = 0; i <= state.Count - Pattern.Count; i++)
            {
                if (IsMatch(state, i))
                {
                    yield return i + 2;
                }
            }
        }

        private bool IsMatch(IList<bool> state, int stateIndex)
        {
            for (var i = 0; i < Pattern.Count; i++)
            {
                if (state[i + stateIndex] != Pattern[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}