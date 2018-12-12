using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal sealed class Tunnel
    {
        private bool[] _lastState;
        private int _lastStateOffset;
        private bool[] _testState;

        public Tunnel(bool[] initialState, IList<SpreadNote> notes)
        {
            _lastState = initialState;
            Notes = notes;
        }

        public IList<SpreadNote> Notes { get; }

        public int GetPlantsCount() => _lastState.Count(i => i);

        public void NextGeneration()
        {
            _lastStateOffset += SpreadStateWithEmpties(ref _lastState);
            if (_testState == null)
            {
                _testState = new bool[_lastState.Length];
            }
            else
            {
                Array.Resize(ref _testState, _lastState.Length);
                Array.Clear(_testState, 0, _testState.Length);
            }

            foreach (var index in Notes.SelectMany(i => i.Match(_lastState)))
            {
                _testState[index] = true;
            }

            Array.Copy(_testState, 0, _lastState, 0, _testState.Length);
        }

        public long SumPlantNumbers()
        {
            var result = 0L;
            var middle = _lastState.Length / 2;

            for (var i = 0; i < middle; i++)
            {
                if (_lastState[i])
                {
                    result += i + _lastStateOffset;
                }

                var j = _lastState.LongLength - i - 1;
                if (_lastState[j])
                {
                    result += j + _lastStateOffset;
                }
            }

            if (_lastState.Length % 2 != 0 && _lastState[middle])
            {
                result += middle + _lastStateOffset;
            }

            return result;
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
            for (var i = state.Length - 1; i >= state.Length - EmptiesCount; i--)
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

            var oldSize = state.Length;
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
