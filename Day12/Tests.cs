using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day12
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";

        [Test]
        public void Task1Solve()
        {
            var input = Example
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            input.Insert(1, string.Empty);

            Task.Solve(input, 20).ShouldBe(325);
        }

        [Test]
        [TestCase("...##", new[] { false, false, false, true, true })]
        [TestCase("#..#.#", new[] { true, false, false, true, false, true })]
        public void ParseInitialState(string definition, bool[] expected)
        {
            InputParser.ParseInitialState(definition).ShouldBe(expected);
        }

        [Test]
        [TestCase("...## => #", new[] { false, false, false, true, true }, true)]
        [TestCase("#.#.# => .", new[] { true, false, true, false, true }, false)]
        public void ParseNote(string definition, bool[] pattern, bool result)
        {
            var note = InputParser.ParseNote(definition);
            if (result)
            {
                note.ShouldNotBeNull();
                note.Pattern.ShouldBe(pattern);
            }
            else
            {
                note.ShouldBeNull();
            }
        }

        [Test]
        [TestCase("..###...###..", "###.. => #", new[] { 4, 10 })]
        public void SpreadNoteMatch(string stateDefinition, string noteDefinition, int[] expected)
        {
            var state = InputParser.ParseInitialState(stateDefinition);
            var note = InputParser.ParseNote(noteDefinition);

            note.Match(state).ToArray().ShouldBe(expected);
        }
    }
}
