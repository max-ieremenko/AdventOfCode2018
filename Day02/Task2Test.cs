using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace Day02
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase("abcde", "fghij", -1)]
        [TestCase("fghij", "fguij", 2)]
        [TestCase("abcde", "abcde", -1)]
        public void FindDiffCharacterIndex(string x, string y, int expected)
        {
            Task2.FindDiffCharacterIndex(x, y).ShouldBe(expected);
        }

        [Test]
        [TestCase(new[] { "fghij", "abcde", "fguij" }, "fgij")]
        [TestCase(new[] { "abcde", "fghij", "fguij" }, "fgij")]
        [TestCase(new[] { "abcde", "fguij", "fghij" }, "fgij")]
        [TestCase(new[] { "fghij", "fguij", "abcde" }, "fgij")]
        public void Solve(IEnumerable<string> input, string expected)
        {
            Task2.Solve(input).ShouldBe(expected);
        }
    }
}
