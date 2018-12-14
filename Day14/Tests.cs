using NUnit.Framework;
using Shouldly;

namespace Day14
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(5, "0124515891")]
        [TestCase(18, "9251071085")]
        [TestCase(2018, "5941429882")]
        public void Task1Solve(int input, string expected)
        {
            Task1.Solve(input).ShouldBe(expected);
        }

        [Test]
        [TestCase("51589", 9)]
        [TestCase("01245", 5)]
        [TestCase("92510", 18)]
        [TestCase("59414", 2018)]
        public void Task2Solve(string input, int expected)
        {
            Task2.Solve(input).ShouldBe(expected);
        }
    }
}
