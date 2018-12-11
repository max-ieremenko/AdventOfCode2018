using NUnit.Framework;
using Shouldly;

namespace Day11
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(18, "33,45")]
        [TestCase(42, "21,61")]
        public void Task1Solve(int gridSerialNumber, string expected)
        {
            Task1.Solve(gridSerialNumber).ShouldBe(expected);
        }

        [Test]
        [TestCase(18, "90,269,16")]
        [TestCase(42, "232,251,12")]
        public void Task2Solve(int gridSerialNumber, string expected)
        {
            Task2.Solve(gridSerialNumber).ShouldBe(expected);
        }

        [Test]
        [TestCase(18, 33, 45, 29)]
        [TestCase(42, 21, 61, 30)]
        public void GetAreaPowerLevel(int gridSerialNumber, int cellX, int cellY, int expected)
        {
            var grid = new Grid(gridSerialNumber);
            grid.GetAreaPowerLevel(cellX, cellY, 3).ShouldBe(expected);
        }

        [Test]
        [TestCase(3, 5, 8, 4)]
        [TestCase(122, 79, 57, -5)]
        [TestCase(217, 196, 39, 0)]
        [TestCase(101, 153, 71, 4)]
        public void CalculateCellPowerLevel(int cellX, int cellY, int gridSerialNumber, int expected)
        {
            var grid = new Grid(gridSerialNumber);
            grid.GetCellPowerLevel(cellX, cellY).ShouldBe(expected);
        }

        [Test]
        [TestCase(18, 90, 269, 16, 113)]
        [TestCase(42, 232, 251, 12, 119)]
        public void GetCellMaxPowerLevel(int gridSerialNumber, int cellX, int cellY, int expectedSize, int expectedPower)
        {
            var grid = new Grid(gridSerialNumber);

            var actual = grid.GetCellMaxPowerLevel(cellX, cellY);
            actual.Key.ShouldBe(expectedPower);
            actual.Value.ShouldBe(expectedSize);
        }
    }
}
