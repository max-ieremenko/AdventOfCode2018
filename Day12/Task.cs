using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal static class Task
    {
        public static long Solve(IEnumerable<string> input, long generationsCount)
        {
            var task = InputParser.Parse(input);
            var notes = task.Notes;

            var state = task.InitialState;
            bool[] newState = null;
            var stateOffset = 0L;

            for (var i = 0; i < generationsCount; i++)
            {
                stateOffset += SpreadStateWithEmpties(ref state);
                if (newState == null)
                {
                    newState = new bool[state.LongLength];
                }
                else
                {
                    Array.Resize(ref newState, state.Length);
                    Array.Clear(newState, 0, newState.Length);
                }

                Spread(state, newState, notes);

                Array.Copy(newState, 0, state, 0, newState.Length);
            }

            return SumNumbers(state, stateOffset);
        }

        private static long SumNumbers(bool[] state, long stateOffset)
        {
            var result = 0L;
            var middle = state.LongLength / 2;

            for (var i = 0L; i < middle; i++)
            {
                if (state[i])
                {
                    result += i + stateOffset;
                }

                var j = state.LongLength - i - 1;
                if (state[j])
                {
                    result += j + stateOffset;
                }
            }

            if (state.LongLength % 2 != 0 && state[middle])
            {
                result += middle + stateOffset;
            }

            return result;
        }

        private static void Spread(bool[] state, bool[] newState, IList<SpreadNote> notes)
        {
            notes
                .AsParallel()
                .SelectMany(note => note.Match(state))
                .ForAll(i => newState[i] = true);
        }

        private static int SpreadStateWithEmpties(ref bool[] state)
        {
            const int EmptiesCount = 5;

            // make ...... at the beginning
            var leftCount = EmptiesCount;
            for (var i = 0; i < EmptiesCount; i++)
            {
                if (state[i])
                {
                    break;
                }

                leftCount--;
            }

            // make .. at the end
            var rightCount = EmptiesCount;
            for (var i = state.LongLength - 1; i >= state.LongLength - EmptiesCount; i--)
            {
                if (state[i])
                {
                    break;
                }

                rightCount--;
            }

            if (rightCount == 0 && leftCount == 0)
            {
                return 0;
            }

            var oldSize = state.LongLength;
            Array.Resize(ref state, state.Length + rightCount + leftCount);
            if (leftCount > 0)
            {
                Array.Copy(state, 0, state, leftCount, oldSize);
                for (var i = 0; i < leftCount; i++)
                {
                    state[i] = false;
                }
            }

            return -leftCount;
        }
    }
}
