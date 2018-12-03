using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class Task2
    {
        public static string Solve(IEnumerable<string> input)
        {
            var claims = input
                .Select(i => new Claim(i))
                .ToList();

            var rects = claims
                .SelectMany(i => i.GetTiles())
                .GroupBy(i => i)
                .ToDictionary(i => i.Key, i => i.Count());

            foreach (var claim in claims)
            {
                if (claim.GetTiles().All(i => rects[i] == 1))
                {
                    return claim.Id;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
