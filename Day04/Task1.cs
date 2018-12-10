using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04
{
    public static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var writer = new RecordsWriter();
            foreach (var record in input.Select(i => new Record(i)).OrderBy(i => i.Date))
            {
                writer.Write(record);
            }

            foreach (var guard in writer.GetGuards().OrderByDescending(i => i.TotalTime))
            {
                var overlaps = guard.GetOverlaps().ToList();
                if (overlaps.Count == 0)
                {
                    continue;
                }

                return guard.Id * overlaps[0].Key.Minutes;
            }

            throw new NotSupportedException();
        }
    }
}
