using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace Day25
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCaseSource(nameof(GetExamples))]
        public void Task1Solve(string input, int expected)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task1.Solve(lines).ShouldBe(expected);
        }

        private static IEnumerable<TestCaseData> GetExamples()
        {
            const string Example1 = @"
0,0,0,0
 3,0,0,0
 0,3,0,0
 0,0,3,0
 0,0,0,3
 0,0,0,6
 9,0,0,0
12,0,0,0";
            yield return new TestCaseData(Example1, 2).SetName("example 1");

            const string Example2 = @"
-1,2,2,0
0,0,2,-2
0,0,0,-2
-1,2,0,0
-2,-2,-2,2
3,0,2,-1
-1,3,2,2
-1,0,-1,0
0,2,1,-2
3,0,0,0";
            yield return new TestCaseData(Example2, 4).SetName("example 2");

            const string Example3 = @"
1,-1,0,1
2,0,-1,0
3,2,-1,0
0,0,3,1
0,0,-1,-1
2,3,-2,0
-2,2,0,0
2,-2,0,-1
1,-1,0,-1
3,2,0,2";
            yield return new TestCaseData(Example3, 3).SetName("example 3");

            const string Example4 = @"
1,-1,-1,-2
-2,-2,0,1
0,2,1,3
-2,3,-2,1
0,2,3,-2
-1,-1,1,-2
0,-2,-1,0
-2,2,3,-1
1,2,2,0
-1,-2,0,-2";
            yield return new TestCaseData(Example4, 8).SetName("example 8");
        }
    }
}
