using System.Collections.Generic;

namespace Day23
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var bots = InputParser.Parse(input);

            var location = new LocationResolver(bots).Resolve();

            return location.GetDistanceTo(default(Point));
        }
    }
}
