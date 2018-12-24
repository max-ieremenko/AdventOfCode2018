using System;
using NUnit.Framework;
using Shouldly;

namespace Day23
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Task1Solve()
        {
            const string Input = @"
pos=<0,0,0>, r=4
pos=<1,0,0>, r=1
pos=<4,0,0>, r=3
pos=<0,2,0>, r=1
pos=<0,5,0>, r=3
pos=<0,0,3>, r=1
pos=<1,1,1>, r=1
pos=<1,1,2>, r=1
pos=<1,3,1>, r=1";

            var rows = Input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(rows).ShouldBe(7);
        }

        [Test]
        public void Task2Solve()
        {
            const string Input = @"
pos=<10,12,12>, r=2
pos=<12,14,12>, r=2
pos=<16,12,12>, r=4
pos=<14,14,14>, r=6
pos=<50,50,50>, r=200
pos=<10,10,10>, r=5";

            var rows = Input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task2.Solve(rows).ShouldBe(36);
        }

        [Test]
        [TestCase("pos=<1,2,3>, r=4", 1, 2, 3, 4)]
        [TestCase("pos=<49475749,-20115131,58139736>, r=69483002", 49475749, -20115131, 58139736, 69483002)]
        public void ParseNanobot(string definition, int x, int y, int z, int radius)
        {
            var bots = InputParser.Parse(new[] { definition });

            bots.Count.ShouldBe(1);
            bots[0].Location.X.ShouldBe(x);
            bots[0].Location.Y.ShouldBe(y);
            bots[0].Location.Z.ShouldBe(z);
            bots[0].Radius.ShouldBe(radius);
        }
    }
}
