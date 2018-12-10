using System;
using System.Diagnostics;
using System.Globalization;

namespace Day04
{
    [DebuggerDisplay("{Date} #{GuardId} {Type}")]
    public struct Record
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm";

        public Record(string definition)
        {
            GuardId = null;
            Date = DateTime.ParseExact(
                definition.Substring(1, DateFormat.Length),
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);

            if (definition.Contains("falls asleep"))
            {
                Type = RecordType.FallsAsleep;
                return;
            }

            if (definition.Contains("wakes up"))
            {
                Type = RecordType.WakesUp;
                return;
            }

            if (!definition.Contains("begins shift"))
            {
                throw new NotSupportedException();
            }

            Type = RecordType.BeginsShift;
            var index = definition.IndexOf('#');
            GuardId = int.Parse(definition.Substring(index + 1, definition.IndexOf(' ', index) - index - 1), CultureInfo.InvariantCulture);
        }

        public DateTime Date { get; }

        public RecordType Type { get; }

        public int? GuardId { get; }
    }
}
