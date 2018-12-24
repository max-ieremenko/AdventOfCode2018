using System.Collections.Generic;

namespace Day23
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var bots = InputParser.Parse(input);

            var largest = FindWithLargestRadius(bots);
            var botsInLargestRange = 0;

            foreach (var bot in bots)
            {
                var distance = bot.Location.GetDistanceTo(largest.Location);
                if (distance <= largest.Radius)
                {
                    botsInLargestRange++;
                }
            }

            return botsInLargestRange;
        }

        private static Nanobot FindWithLargestRadius(IList<Nanobot> bots)
        {
            var result = bots[0];
            for (var i = 1; i < bots.Count; i++)
            {
                var bot = bots[i];
                if (bot.Radius > result.Radius)
                {
                    result = bot;
                }
            }

            return result;
        }
    }
}
