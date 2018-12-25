using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var groups = FindGroups(bots);

            var tasks = groups
                .Select(i => Task.Factory.StartNew(() => FindTarget(i), TaskCreationOptions.LongRunning))
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var target in tasks.Select(i => i.Result))
            {
                Console.WriteLine("{0}: {1} bots, {2} length", target.Location, target.Count, target.Distance);
            }

            return 1;
        }

        private static Target FindTarget(IList<Nanobot> bots)
        {
            var visited = new HashSet<Point>();
            var betsLocation = new Point(0, 0, 0);
            var bestBotsCount = 0;
            var bestDistance = 0;
            var bestBotsRepeated = 0;

            var step = 0;
            while (true)
            {
                var lastCount = bestBotsCount;

                foreach (var bot in bots)
                {
                    foreach (var point in GetStepPoints(bot, step).Where(i => i.GetDistanceTo(bot.Location) <= bot.Radius))
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
                            betsLocation = point;
                        }
                        else if (botsCount == bestBotsCount)
                        {
                            var distance = point.GetDistanceTo(new Point(0, 0, 0));
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                betsLocation = point;
                            }
                        }
                    }
                }

                if (lastCount == bestBotsCount)
                {
                    bestBotsRepeated++;
                }
                else
                {
                    bestBotsRepeated = 0;
                }

                if (bestBotsRepeated > 7)
                {
                    break;
                }

                step++;
            }

            return new Target(betsLocation, bestBotsCount, bestDistance);
        }

        private static IList<Nanobot[]> FindGroups(IList<Nanobot> bots)
        {
            var groups = new List<ICollection<Nanobot>>();
            var groupsCount = 0;

            foreach (var bot in bots)
            {
                var intersections = bots.Where(i => i.IntersectsWith(bot)).ToHashSet();
                if (intersections.Count > groupsCount)
                {
                    groupsCount = intersections.Count;
                    groups.Clear();
                    groups.Add(intersections);
                }
                else if (intersections.Count == groupsCount)
                {
                    var add = false;
                    for (var i = 0; i < groups.Count; i++)
                    {
                        var group = groups[i];

                        if (intersections.IsSupersetOf(group))
                        {
                            groups.RemoveAt(i);
                            add = true;
                            i--;
                        }
                        else if (intersections.IsSupersetOf(group))
                        {
                        }
                        else
                        {
                            add = true;
                        }
                    }

                    if (add)
                    {
                        groups.Add(intersections);
                    }
                }
            }

            return groups.Select(i => i.ToArray()).ToArray();
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

        private struct Target
        {
            public Target(Point location, int count, int distance)
            {
                Location = location;
                Count = count;
                Distance = distance;
            }

            public Point Location { get; }

            public int Count { get; }

            public int Distance { get; }
        }
    }
}
