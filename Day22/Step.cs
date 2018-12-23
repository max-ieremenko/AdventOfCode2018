using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day22
{
    internal sealed class Step
    {
        private readonly StepState _destination;
        private readonly int _destinationLength;
        private Step _previous;

        public Step(StepState state, StepState destination, Step previous)
        {
            _destination = destination;
            _previous = previous;
            State = state;

            _destinationLength = Math.Abs(state.Location.X - destination.Location.X) + Math.Abs(state.Location.Y - destination.Location.Y);
            EstimatedDestinationValue = _destinationLength;
            if (previous != null)
            {
                Value = CalculateValue(previous);
                EstimatedDestinationValue += Value;
            }
        }

        public StepState State { get; }

        public bool IsVisited { get; set; }

        public int Value { get; private set; }

        public int EstimatedDestinationValue { get; private set; }

        public void TryOtherPrevious(Step previous)
        {
            var testValue = CalculateValue(previous);
            if (testValue < Value)
            {
                Value = testValue;
                EstimatedDestinationValue = testValue + _destinationLength;
                _previous = previous;
            }
        }

        public override string ToString()
        {
            var list = new List<StepState>();

            var current = this;
            while (current != null)
            {
                list.Insert(0, current.State);
                current = current._previous;
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}: {1}",
                Value,
                string.Join(" => ", list.Select(i => i.ToString())));
        }

        private int CalculateValue(Step previous)
        {
            var value = previous.Value + 1;
            if (previous.State.Tool != State.Tool)
            {
                value += 7;
            }

            if (State.Location == _destination.Location && State.Tool != _destination.Tool)
            {
                value += 7;
            }

            return value;
        }
    }
}
