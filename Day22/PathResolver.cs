using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day22
{
    internal sealed class PathResolver
    {
        private readonly CaveSystem _caves;

        public PathResolver(CaveSystem caves)
        {
            _caves = caves;
        }

        public Step FindPath(Point initialLocation, Tool initialTool)
        {
            var destinationState = new StepState(_caves.Target, Tool.Torch);
            var initialState = new StepState(initialLocation, initialTool);

            var initialStep = new Step(initialState, destinationState, null);
            var stepByState = new Dictionary<StepState, Step>
            {
                { initialState, initialStep }
            };
            var queue = new List<Step> { initialStep };

            while (queue.Count > 0)
            {
                queue.Sort((x, y) => x.EstimatedDestinationValue.CompareTo(y.EstimatedDestinationValue));

                var current = queue[0];
                queue.RemoveAt(0);
                current.IsVisited = true;

                if (current.State.Location == _caves.Target)
                {
                    return current;
                }

                foreach (var nextState in GetNeighborStates(current.State.Location).Where(i => CanBeOccupied(i, current.State)))
                {
                    if (!stepByState.TryGetValue(nextState, out var next))
                    {
                        next = new Step(nextState, destinationState, current);
                        stepByState.Add(nextState, next);
                        queue.Add(next);
                    }
                    else if (!next.IsVisited)
                    {
                        next.TryOtherPrevious(current);
                    }
                }
            }

            return null;
        }

        private bool CanBeOccupied(StepState state, StepState fromState)
        {
            if (state.Tool == fromState.Tool)
            {
                return true;
            }

            return _caves.GetGaveAvailableTools(fromState.Location).Contains(state.Tool);
        }

        private IEnumerable<StepState> GetNeighborStates(Point location)
        {
            return GetNeighborLocations(location)
                .Where(_caves.WithingSystem)
                .SelectMany(l => _caves.GetGaveAvailableTools(l).Select(t => new StepState(l, t)));
        }

        private IEnumerable<Point> GetNeighborLocations(Point location)
        {
            yield return new Point(location.X, location.Y - 1);
            yield return new Point(location.X - 1, location.Y);
            yield return new Point(location.X + 1, location.Y);
            yield return new Point(location.X, location.Y + 1);
        }
    }
}
