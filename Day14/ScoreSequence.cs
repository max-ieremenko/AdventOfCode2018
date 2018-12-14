using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day14
{
    internal sealed class ScoreSequence
    {
        private int _lastScoreboardOffset;

        public ScoreSequence(string pattern)
        {
            Pattern = pattern.Select(i => byte.Parse(i.ToString(), CultureInfo.InvariantCulture)).ToArray();
        }

        public byte[] Pattern { get; }

        public int Matches(IList<byte> scores)
        {
            while (_lastScoreboardOffset + Pattern.Length < scores.Count + 1)
            {
                if (Matches(scores, _lastScoreboardOffset, Pattern))
                {
                    return _lastScoreboardOffset;
                }

                _lastScoreboardOffset++;
            }

            return -1;
        }

        private static bool Matches(IList<byte> scores, int scoreboardOffset, IList<byte> pattern)
        {
            for (var i = 0; i < pattern.Count; i++)
            {
                var x = scores[scoreboardOffset + i];
                var y = pattern[i];
                if (x != y)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
