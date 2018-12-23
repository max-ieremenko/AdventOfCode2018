using System.Drawing;
using NUnit.Framework;
using Shouldly;

namespace Day22
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(510, 10, 10, 114)]
        public void Task1Solve(int depth, int targetX, int targetY, int expected)
        {
            Task1.Solve(depth, new Point(targetX, targetY)).ShouldBe(expected);
        }

        [Test]
        [TestCase(510, 10, 10, 45)]
        public void Task2Solve(int depth, int targetX, int targetY, int expected)
        {
            Task2.Solve(depth, new Point(targetX, targetY)).ShouldBe(expected);
        }

        [Test]
        [TestCase(1, 1, RegionType.Narrow)]
        public void GetCaveType(int x, int y, RegionType expected)
        {
            var caves = new CaveSystem(510, new Point(10, 10));
            caves.GetCaveType(new Point(x, y)).ShouldBe(expected);
        }
    }
}
