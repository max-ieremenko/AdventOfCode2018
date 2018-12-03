using NUnit.Framework;
using Shouldly;

namespace Day2
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("abcdef", false, false)]
        [TestCase("bababc", true, true)]
        [TestCase("abbcde", true, false)]
        [TestCase("abcccd", false, true)]
        [TestCase("aabcdd", true, false)]
        [TestCase("abcdee", true, false)]
        [TestCase("ababab", false, true)]
        public void GetCounters(string input, bool expectedTwo, bool expectedThree)
        {
            var actual = Task1.GetCounters(input);
            actual.Two.ShouldBe(expectedTwo);
            actual.Three.ShouldBe(expectedThree);
        }
    }
}
