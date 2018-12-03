using NUnit.Framework;
using Shouldly;

namespace Day1
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase(new[] { "+1", "+1", "+1" }, 3)]
        [TestCase(new[] { "+1", "+1", "-2" }, 0)]
        [TestCase(new[] { "-1", "-2", "-3" }, -6)]
        public void Solve(string[] input, int expected)
        {
            Task1.Solve(input).ShouldBe(expected);
        }
    }
}
