using NUnit.Framework;
using Shouldly;

namespace Day9
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(9, 25, 32)]
        [TestCase(10, 1618, 8317)]
        [TestCase(13, 7999, 146373)]
        [TestCase(17, 1104, 2764)]
        [TestCase(21, 6111, 54718)]
        [TestCase(30, 5807, 37305)]
        public void TasksSolve(int playersCount, int lastMarbleNumber, int expected)
        {
            Task.Solve(playersCount, lastMarbleNumber).ShouldBe(expected);
        }
    }
}
