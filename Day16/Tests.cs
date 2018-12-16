using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Day16
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Task1Example()
        {
            var input = new[]
            {
                "Before: [3, 2, 1, 1]",
                "9 2 1 2",
                "After:  [3, 2, 2, 1]"
            };

            var sample = InputParser.Parse(input).Samples.Single();
            var opCodes = OpCodeFactory.GetAllOpCodes();

            var matches = new List<string>();
            foreach (var opCode in opCodes)
            {
                var context = new OpCodeContext(sample.RegistersBefore);
                opCode.A = sample.A;
                opCode.B = sample.B;
                opCode.C = sample.C;

                opCode.Invoke(context);
                if (context.IsMatch(sample.RegistersAfter))
                {
                    matches.Add(opCode.GetType().Name);
                }
            }

            matches.Count.ShouldBe(3);
        }

        [Test]
        public void ParseSamples()
        {
            var input = new[]
            {
                "Before: [2, 3, 2, 2]",
                "15 3 2 2",
                "After:  [2, 3, 4, 2]",
                string.Empty,
                "Before: [3, 2, 2, 1]",
                "3 1 0 1",
                "After:  [3, 1, 2, 1]"
            };

            var samples = InputParser.Parse(input).Samples;
            samples.Count.ShouldBe(2);

            samples[0].RegistersBefore.ShouldBe(new[] { 2, 3, 2, 2 });
            samples[0].A.ShouldBe(3);
            samples[0].B.ShouldBe(2);
            samples[0].C.ShouldBe(2);
            samples[0].RegistersAfter.ShouldBe(new[] { 2, 3, 4, 2 });

            samples[1].RegistersBefore.ShouldBe(new[] { 3, 2, 2, 1 });
            samples[1].A.ShouldBe(1);
            samples[1].B.ShouldBe(0);
            samples[1].C.ShouldBe(1);
            samples[1].RegistersAfter.ShouldBe(new[] { 3, 1, 2, 1 });
        }
    }
}
