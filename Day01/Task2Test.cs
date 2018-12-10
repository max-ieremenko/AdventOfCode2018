using NUnit.Framework;
using Shouldly;

namespace Day01
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase(new[] { "+1", "-1" }, 0)]
        [TestCase(new[] { "+3", "+3", "+4", "-2", "-4" }, 10)]
        [TestCase(new[] { "-6", "+3", "+8", "+5", "-6" }, 5)]
        [TestCase(new[] { "+7", "+7", "-2", "-7", "-4" }, 14)]
        public void Solve(string[] input, int expected)
        {
            Task2.Solve(input).ShouldBe(expected);
        }
    }
}
