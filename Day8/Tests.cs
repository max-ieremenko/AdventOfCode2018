using NUnit.Framework;
using Shouldly;

namespace Day8
{
    [TestFixture]
    public class Tests
    {
        private const string Example = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

        [Test]
        public void Task1Solve()
        {
            Task1.Solve(Example).ShouldBe(138);
        }

        [Test]
        public void Task2Solve()
        {
            Task2.Solve(Example).ShouldBe(66);
        }
    }
}
