using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23
{
    internal static class Task2
    {
        /*
         *
         *
107372481
107372461
107372461
105808022
107372469
105808022
         */
        public static int Solve(IEnumerable<string> input)
        {
            var bots = InputParser.Parse(input);

            var visited = new HashSet<Point>();
            var bestLocation = new Point(0, 0, 0);
            var bestBotsCount = 0;
            var bestDistance = 0;

            var step = 0;
            while (true)
            {
                foreach (var bot in bots)
                {
                    foreach (var point in GetStepPoints(bot, step).Where(i => i.GetDistanceTo(bot.Location) == bot.Radius))
                    {
                        if (!visited.Add(point))
                        {
                            continue;
                        }

                        var botsCount = bots.Count(i => i.InRange(point));
                        if (botsCount > bestBotsCount)
                        {
                            bestBotsCount = botsCount;
                            bestDistance = point.GetDistanceTo(new Point(0, 0, 0));
                            bestLocation = point;
                        }
                        else if (botsCount == bestBotsCount)
                        {
                            bestDistance = Math.Min(bestDistance, point.GetDistanceTo(new Point(0, 0, 0)));
                            bestLocation = point;
                        }
                    }
                }

                Console.WriteLine("{0}: {1} bots {2} length", bestLocation, bestBotsCount, bestDistance);
                if (step > 1000)
                {
                    break;
                }

                step++;
            }

            return bestDistance;
        }

        private static IEnumerable<Point> GetStepPoints(Nanobot bot, int step)
        {
            var vertices = new[]
            {
                new Point(bot.Location.X, bot.Location.Y, bot.Location.Z + bot.Radius),
                new Point(bot.Location.X, bot.Location.Y, bot.Location.Z - bot.Radius),
                new Point(bot.Location.X, bot.Location.Y + bot.Radius, bot.Location.Z),
                new Point(bot.Location.X, bot.Location.Y - bot.Radius, bot.Location.Z),
                new Point(bot.Location.X + bot.Radius, bot.Location.Y, bot.Location.Z),
                new Point(bot.Location.X - bot.Radius, bot.Location.Y, bot.Location.Z)
            };

            foreach (var vertex in vertices)
            {
                for (var x = vertex.X - step; x <= vertex.X + step; x++)
                {
                    for (var y = vertex.Y - step; y <= vertex.Y + step; y++)
                    {
                        yield return new Point(x, y, vertex.Z);
                    }
                }

                for (var x = vertex.X - step; x <= vertex.X + step; x++)
                {
                    for (var z = vertex.Z - step; z <= vertex.Z + step; z++)
                    {
                        yield return new Point(x, vertex.Y, z);
                    }
                }

                for (var z = vertex.Z - step; z <= vertex.Z + step; z++)
                {
                    for (var y = vertex.Y - step; y <= vertex.Y + step; y++)
                    {
                        yield return new Point(vertex.X, y, z);
                    }
                }
            }
        }
    }
}
