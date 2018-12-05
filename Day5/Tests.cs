using System.Text;
using NUnit.Framework;
using Shouldly;

namespace Day5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("aA", "")]
        [TestCase("abBA", "")]
        [TestCase("abAB", "abAB")]
        [TestCase("aabAAB", "aabAAB")]
        [TestCase("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        [TestCase("cxaFffFAXb", "cb")]
        public void Task1React(string input, string expected)
        {
            var test = new StringBuilder(input);
            Task1.React(test);
            test.ToString().ShouldBe(expected);
        }

        [Test]
        [TestCase("dabAcCaCBAcCcaDA\n", 4)]
        public void Task2Solve(string input, int expected)
        {
            Task2.Solve(input).ShouldBe(expected);
        }

        [Test]
        [TestCase('a', 'A', true)]
        [TestCase('A', 'a', true)]
        [TestCase('a', 'a', false)]
        [TestCase('a', 'b', false)]
        public void AreOpposite(char x, char y, bool expected)
        {
            Task1.AreOpposite(x, y).ShouldBe(expected);
        }
    }
}
