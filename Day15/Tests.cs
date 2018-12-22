using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace Day15
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCaseSource(nameof(ParseInput), new object[] { "task1Examples.txt" })]
        public void Task1Solve(IEnumerable<string> input, int expectedOutcome)
        {
            Task1.Solve(input).ShouldBe(expectedOutcome);
        }

        [Test]
        [TestCaseSource(nameof(ParseInput), new object[] { "task2Examples.txt" })]
        public void Task2Solve(IEnumerable<string> input, int expectedOutcome)
        {
            Task2.Solve(input).ShouldBe(expectedOutcome);
        }

        [Test]
        public void MovementExample()
        {
            Map actual = null;
            foreach (var test in ParseInput("movementExamples.txt"))
            {
                var map = InputParser.Parse((IEnumerable<string>)test.Arguments[0]);
                if (actual == null)
                {
                    actual = map;
                }
                else
                {
                    actual.NexRound().CombatIsFinished.ShouldBe(false);
                    actual.ToString().ShouldBe(map.ToString());
                }
            }
        }

        private static IEnumerable<TestCaseData> ParseInput(string fileName)
        {
            const string Outcome = "Outcome: ";

            var task = new List<string>();
            var counter = 1;

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
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
                        yield return new TestCaseData(
                                task.ToArray(),
                                int.Parse(line.Substring(Outcome.Length), CultureInfo.InvariantCulture))
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
