using System;
using NUnit.Framework;
using Shouldly;

namespace Day06
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9";

        [Test]
        public void Task1Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(input).ShouldBe(17);
        }

        [Test]
        public void Task2Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task2.Solve(input, 32).ShouldBe(16);
        }
    }
}
