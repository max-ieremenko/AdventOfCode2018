using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day3
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" }, 4)]
        public void Task1Solve(IEnumerable<string> input, int expected)
        {
            Task1.Solve(input).ShouldBe(expected);
        }

        [Test]
        [TestCase("#1 @ 1,3: 4x4", "1", 1, 3, 4, 4)]
        [TestCase("#3 @ 5,5: 2x2", "3", 5, 5, 2, 2)]
        public void ParseClaim(string definition, string id, int left, int top, int with, int height)
        {
            var actual = new Claim(definition);
            actual.Id.ShouldBe(id);
            actual.Left.ShouldBe(left);
            actual.Top.ShouldBe(top);
            actual.With.ShouldBe(with);
            actual.Height.ShouldBe(height);
        }

        [Test]
        public void GetTiles()
        {
            var actual = new Claim("3 @ 5,5: 2x2").GetTiles().ToList();

            actual.Count.ShouldBe(4);
            actual.ShouldBe(
                new[]
                {
                    new Tile(5, 5),
                    new Tile(5, 6),
                    new Tile(6, 5),
                    new Tile(6, 6),
                });
        }
    }
}
