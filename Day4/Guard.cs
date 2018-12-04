using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public sealed class Guard
    {
        private readonly IDictionary<TimeSpan, int> _sleepByMinute;

        public Guard(int id)
        {
            Id = id;
            _sleepByMinute = new Dictionary<TimeSpan, int>();
        }

        public int Id { get; }

        public int TotalTime { get; private set; }

        public IEnumerable<KeyValuePair<TimeSpan, int>> GetOverlaps()
        {
            return _sleepByMinute
                .Where(i => i.Value > 1)
                .OrderByDescending(i => i.Value);
        }

        public void Sleep(DateTime start, DateTime end)
        {
            if (end <= start)
            {
                throw new ArgumentOutOfRangeException();
            }

            var interval = (int)(end - start).TotalMinutes;
            if (interval > 60)
            {
                throw new ArgumentOutOfRangeException();
            }

            TotalTime += interval;

            for (var i = start; i < end; i = i.AddMinutes(1))
            {
                var minute = new TimeSpan(i.Hour, i.Minute, 0);
                _sleepByMinute.TryGetValue(minute, out var value);
                _sleepByMinute[minute] = value + 1;
            }
        }
    }
}