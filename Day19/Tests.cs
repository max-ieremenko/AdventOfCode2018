using System;
using NUnit.Framework;
using Shouldly;

namespace Day19
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"
#ip 0
seti 5 0 1
seti 6 0 2
addi 0 1 0
addr 1 2 3
setr 1 0 0
seti 8 0 4
seti 9 0 5";

        [Test]
        public void Task1Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(input).ShouldBe(7);
        }

        [Test]
        public void Task2Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task2.Solve(input).ShouldBe(12);
        }
    }
}
