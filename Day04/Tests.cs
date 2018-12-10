using System;
using NUnit.Framework;
using Shouldly;

namespace Day04
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up";

        [Test]
        public void Task1Solve()
        {
            var lines = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task1.Solve(lines).ShouldBe(240);
        }

        [Test]
        public void Task2Solve()
        {
            var lines = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Task2.Solve(lines).ShouldBe(4455);
        }

        [Test]
        [TestCase("[1518-05-31 00:27] falls asleep", "1518-05-31 00:27", RecordType.FallsAsleep, null)]
        [TestCase("[1518-02-08 00:41] wakes up", "1518-02-08 00:41", RecordType.WakesUp, null)]
        [TestCase("[1518-11-21 00:00] Guard #3203 begins shift", "1518-11-21 00:00", RecordType.BeginsShift, 3203)]
        public void ParseRecord(string line, string date, RecordType recordType, int? guardId)
        {
            var actual = new Record(line);

            actual.Date.ToString("yyyy-MM-dd HH:mm").ShouldBe(date);
            actual.Type.ShouldBe(recordType);
            actual.GuardId.ShouldBe(guardId);
        }
    }
}
