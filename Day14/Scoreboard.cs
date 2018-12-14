using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Day14
{
    internal sealed class Scoreboard
    {
        private readonly IList<byte> _scores;
        private int _elf1Pointer;
        private int _elf2Pointer;

        public Scoreboard(int expectedCapacity)
        {
            _scores = new List<byte>(expectedCapacity) { 3, 7 };
            Scores = new ReadOnlyCollection<byte>(_scores);

            _elf1Pointer = 0;
            _elf2Pointer = 1;
        }

        public IList<byte> Scores { get; }

        public void CreateNewRecipe()
        {
            var elf1Recipe = _scores[_elf1Pointer];
            var elf2Recipe = _scores[_elf2Pointer];
            var newRecipe = elf1Recipe + elf2Recipe;

            if (newRecipe >= 10)
            {
                _scores.Add(1);
                _scores.Add((byte)(newRecipe - 10));
            }
            else
            {
                _scores.Add((byte)newRecipe);
            }

            _elf1Pointer = (_elf1Pointer + elf1Recipe + 1) % _scores.Count;
            _elf2Pointer = (_elf2Pointer + elf2Recipe + 1) % _scores.Count;
        }
    }
}
