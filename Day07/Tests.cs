using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day07
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";

        [Test]
        public void Task1Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(input).ShouldBe("CABDFE");
        }

        [Test]
        public void Task2Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task2.Solve(input, 0, 2).ShouldBe(15);
        }

        [Test]
        public void Parse()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var steps = Parser.Parse(input);

            steps.Select(i => i.Name).ShouldBe(new[] { "A", "B", "C", "D", "E", "F" });
            steps[0].DependsOn.ShouldBe(new[] { "C" });
            steps[1].DependsOn.ShouldBe(new[] { "A" });
        }
    }
}
