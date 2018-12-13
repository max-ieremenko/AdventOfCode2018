using System;
using NUnit.Framework;
using Shouldly;

namespace Day13
{
    [TestFixture]
    public class Tests
    {
        private const string Task1Example = @"
/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   
";

        private const string Task2Example = @"
/>-<\  
|   |  
| /<+-\
| | | v
\>+</ |
  |   ^
  \<->/   
";

        [Test]
        public void Task1Solve()
        {
            var input = Task1Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task1.Solve(input).ShouldBe("7,3");
        }

        [Test]
        public void Task2Solve()
        {
            var input = Task2Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task2.Solve(input).ShouldBe("6,4");
        }

        [Test]
        public void ShowTask1Example()
        {
            var input = Task1Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var track = InputParser.ParseTrack(input);
            Console.WriteLine(track);

            for (var i = 0; i < 14; i++)
            {
                track.Tick();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(track);
            }
        }

        [Test]
        public void ShowTask2Example()
        {
            var input = Task2Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var track = InputParser.ParseTrack(input);
            Console.WriteLine(track);

            for (var i = 0; i < 4; i++)
            {
                track.Tick();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(track);
            }
        }
    }
}
