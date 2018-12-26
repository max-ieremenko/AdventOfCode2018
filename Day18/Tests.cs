using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day18
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Task1Solve()
        {
            var lines = GetExamples().First().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(lines).ShouldBe(1147);
        }

        [Test]
        public void Examples()
        {
            Map actual = null;
            var minute = 0;
            foreach (var example in GetExamples())
            {
                var lines = example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var map = InputParser.Parse(lines);

                if (actual == null)
                {
                    Console.WriteLine("Initially");
                    Console.WriteLine(map);
                    actual = map;
                }
                else
                {
                    minute++;
                    actual.NextMinute();
                    Console.WriteLine("After {0} minute", minute);
                    Console.WriteLine(actual);
                    actual.ToString().ShouldBe(map.ToString());
                }
            }
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, null)]
        [TestCase(new[] { 1, 2, 3, 1, 2 }, null)]
        public void FindPattern(int[] input, int[] expected)
        {
            Task2.FindPattern(input.ToList()).ShouldBe(expected);
        }

        private static IEnumerable<string> GetExamples()
        {
            yield return @"
.#.#...|#.
.....#|##|
.|..|...#.
..|#.....#
#.#|||#|#|
...#.||...
.|....|...
||...#|.#|
|.||||..|.
...#.|..|.";

            yield return @"
.......##.
......|###
.|..|...#.
..|#||...#
..##||.|#|
...#||||..
||...|||..
|||||.||.|
||||||||||
....||..|.";

            yield return @"
.......#..
......|#..
.|.|||....
..##|||..#
..###|||#|
...#|||||.
|||||||||.
||||||||||
||||||||||
.|||||||||";

            yield return @"
.......#..
....|||#..
.|.||||...
..###|||.#
...##|||#|
.||##|||||
||||||||||
||||||||||
||||||||||
||||||||||";
        }
    }
}
