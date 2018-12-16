using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day15
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCaseSource(nameof(GetExamples))]
        public void Task1Solve(IEnumerable<string> input, int expected)
        {
            Task1.Solve(input).ShouldBe(expected);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void ShowExample(int number)
        {
            var testCase = GetExamples().Skip(number - 1).First();
            var map = InputParser.Parse((IEnumerable<string>)testCase.Arguments[0]);

            Console.WriteLine("Initially:");
            Console.WriteLine(map);

            var round = 1;
            while (!map.NexRound().CombatIsFinished)
            {
                Console.WriteLine("After {0} round:", round);
                Console.WriteLine(map);

                var rows = map.Units.Max(i => i.Location.Y);
                for (var row = 0; row <= rows; row++)
                {
                    var units = map.Units.Where(i => i.Location.Y == row).OrderBy(i => i.Location.X).ToList();
                    if (units.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", units.Select(i => string.Format("{0}({1})", i.Flag, i.HitPoints))));
                    }
                }

                round++;
            }
        }

        [Test]
        [TestCase(2, 1, 4, 2, 3, 1)]
        public void FindPath(int fromX, int fromY, int toX, int toY, int expectedX, int expectedY)
        {
            var testCase = GetExamples().First();
            var map = InputParser.Parse((IEnumerable<string>)testCase.Arguments[0]);

            var direction = map.CreatePathResolver().FindPath(new Point(fromX, fromY), new Point(toX, toY));
            direction.ShouldNotBeNull();
            direction.Length.ShouldBe(3);
            direction.FirstStep.ShouldBe(new Point(expectedX, expectedY));
        }

        private static IEnumerable<TestCaseData> GetExamples()
        {
            const string Outcome = "Outcome: ";

            var task = new List<string>();
            var counter = 1;

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "examples.txt")))
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
                        yield return new TestCaseData(task.ToArray(), int.Parse(line.Substring(Outcome.Length), CultureInfo.InvariantCulture))
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
    }
}
