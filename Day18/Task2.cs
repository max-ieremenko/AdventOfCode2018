using System.Collections.Generic;

namespace Day18
{
    internal static class Task2
    {
        private const int Timeout = 1000000000;

        public static int Solve(IEnumerable<string> input)
        {
            var map = InputParser.Parse(input);

            var sequence = new List<int>();
            IList<int> pattern = null;
            for (var i = 1; i <= Timeout; i++)
            {
                map.NextMinute();

                if (i >= 1000)
                {
                    sequence.Add(map.GetResourceValue());

                    pattern = FindPattern(sequence);
                    if (pattern != null)
                    {
                        break;
                    }
                }
            }

            var index = (Timeout - 1000) % pattern.Count;
            return pattern[index];
        }

        internal static IList<int> FindPattern(List<int> sequence)
        {
            if (sequence.Count < 3)
            {
                return null;
            }

            var length = sequence.IndexOf(sequence[0], 1);
            if (length < 0 || (length * 3) > sequence.Count)
            {
                return null;
            }

            for (var i = 0; i < length; i++)
            {
                var value = sequence[i];
                var test1 = i + length;
                var test2 = i + (length * 2);

                if (test2 >= sequence.Count || sequence[test1] != value || sequence[test2] != value)
                {
                    return null;
                }
            }

            var result = new int[length];
            sequence.CopyTo(0, result, 0, length);
            return result;
        }
    }
}
