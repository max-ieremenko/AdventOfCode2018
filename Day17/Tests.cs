using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day17
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"
x=495, y=2..7
y=7, x=495..501
x=501, y=3..7
x=498, y=2..4
x=506, y=1..2
x=498, y=10..13
x=504, y=10..13
y=13, x=498..504";

        [Test]
        public void TaskSolve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(input).ShouldBe(57);
        }

        [Test]
        public void ParseInputX()
        {
            var input = new[] { "x=495, y=2..7" };
            var map = InputParser.Parse(input);

            map[new Point(495, 2)].ShouldBe(GroundType.Clay);
            map[new Point(495, 5)].ShouldBe(GroundType.Clay);
            map[new Point(495, 7)].ShouldBe(GroundType.Clay);

            map[new Point(495, 1)].ShouldBe(GroundType.Sand);
            map[new Point(495, 8)].ShouldBe(GroundType.Sand);

            map[map.Spring].ShouldBe(GroundType.Water);
        }

        [Test]
        public void ParseInputY()
        {
            var input = new[] { "y=13, x=498..504" };
            var map = InputParser.Parse(input);

            map[new Point(498, 13)].ShouldBe(GroundType.Clay);
            map[new Point(504, 13)].ShouldBe(GroundType.Clay);
            map[new Point(500, 13)].ShouldBe(GroundType.Clay);

            map[new Point(497, 13)].ShouldBe(GroundType.Sand);
            map[new Point(505, 13)].ShouldBe(GroundType.Sand);
        }

        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void TestCases(IEnumerable<string> input, int expected)
        {
            var map = InputParser.Parse(input);

            var spring = new Spring(map);
            spring.Output = Console.Out;
            spring.Fill();

            map.GetCellsNumberWithWater().ShouldBe(expected);
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            const string Outcome = "Outcome: ";

            var task = new List<string>();
            var counter = 1;

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCases.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length == 0)
                    {
                        continue;
                    }

                    if (line.StartsWith(Outcome))
                    {
                        yield return new TestCaseData(ConvertMapIntoInput(task), int.Parse(line.Substring(Outcome.Length), CultureInfo.InvariantCulture))
                            .SetName("Example " + counter);

                        task.Clear();
                        counter++;
                    }
                    else
                    {
                        task.Add(line);
                    }
                }
            }
        }

        private static IEnumerable<string> ConvertMapIntoInput(IList<string> map)
        {
            var springIndex = map[0].IndexOf((char)GroundType.Spring);
            var xOffset = 500 - springIndex;

            var result = new List<string>();
            for (var y = 0; y < map.Count; y++)
            {
                var line = map[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == (char)GroundType.Clay)
                    {
                        result.Add(string.Format(CultureInfo.InvariantCulture, "x={0}, y={1}..{1}", x + xOffset, y));
                    }
                }
            }

            return result;
        }
    }
}
