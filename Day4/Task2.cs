using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var writer = new RecordsWriter();
            foreach (var record in input.Select(i => new Record(i)).OrderBy(i => i.Date))
            {
                writer.Write(record);
            }

            var winner = writer
                .GetGuards()
                .Where(i => i.GetOverlaps().Any())
                .Select(
                    i => new
                    {
                        i.Id,
                        Minute = i.GetOverlaps().First().Key.Minutes,
                        Count = i.GetOverlaps().First().Value
                    })
                .OrderByDescending(i => i.Count)
                .First();

            return winner.Id * winner.Minute;
        }
    }
}
