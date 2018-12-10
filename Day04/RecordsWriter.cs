using System;
using System.Collections.Generic;

namespace Day04
{
    internal sealed class RecordsWriter
    {
        private readonly IDictionary<int, Guard> _guardById = new Dictionary<int, Guard>();

        private Guard _guard;
        private DateTime? _startSleep;

        public void Write(Record record)
        {
            if (record.Type == RecordType.BeginsShift)
            {
                if (_startSleep.HasValue)
                {
                    throw new NotSupportedException();
                }

                if (!_guardById.TryGetValue(record.GuardId.Value, out _guard))
                {
                    _guard = new Guard(record.GuardId.Value);
                    _guardById.Add(_guard.Id, _guard);
                }

                return;
            }

            if (record.Type == RecordType.FallsAsleep)
            {
                if (_startSleep.HasValue)
                {
                    throw new NotSupportedException();
                }

                _startSleep = record.Date;
                return;
            }

            if (record.Type != RecordType.WakesUp || !_startSleep.HasValue)
            {
                throw new NotSupportedException();
            }

            _guard.Sleep(_startSleep.Value, record.Date);
            _startSleep = null;
        }

        public IEnumerable<Guard> GetGuards()
        {
            return _guardById.Values;
        }
    }
}
