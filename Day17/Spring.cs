using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Day17
{
    internal sealed class Spring
    {
        private readonly Map _map;
        private readonly IList<SpringStep> _queue;

        public Spring(Map map)
        {
            _map = map;
            _queue = new List<SpringStep>();
        }

        public TextWriter Output { get; set; }

        public void Fill()
        {
            Output?.WriteLine("Initially");
            Output?.WriteLine(_map);

            var location = _map.Spring;
            InvestigateDown(location, location);
            InvestigateLeft(location, location);
            InvestigateRight(location, location);

            var round = 1;
            while (_queue.Count > 0)
            {
                var current = _queue[_queue.Count - 1];
                _queue.RemoveAt(_queue.Count - 1);

                location = Move(current.StartOn, current.Direction, current.Length);
                InvestigateDown(location, current.DownEntryPoint);
                InvestigateLeft(location, current.DownEntryPoint);
                InvestigateRight(location, current.DownEntryPoint);
                InvestigateUp(location, current.DownEntryPoint);

                Output?.WriteLine("Round {0}", round);
                Output?.WriteLine(_map);

                round++;
            }
        }

        private Point Move(Point fromPosition, FlowDirection direction, int length)
        {
            var position = fromPosition;
            _map[position] = GroundType.Water;

            while (length > 0)
            {
                position = position.Move(direction);
                _map[position] = GroundType.Water;
                length--;
            }

            return position;
        }

        private void InvestigateDown(Point fromPosition, Point downEntryPoint)
        {
            var length = 0;

            var location = fromPosition.Down();
            while (_map[location] == GroundType.Sand && location.Y <= _map.RightBottom.Y)
            {
                length++;
                location = location.Down();
            }

            if (length > 0)
            {
                _queue.Add(new SpringStep(fromPosition.Down(), FlowDirection.Down, length - 1, fromPosition));
            }
        }

        private void InvestigateUp(Point fromPosition, Point downEntryPoint)
        {
            var location = new Point(downEntryPoint.X, fromPosition.Y);

            if (location.Y < _map.LeftTop.Y || _map[location] != GroundType.Water)
            {
                return;
            }

            var hasWall = false;
            var leftLength = 0;
            for (var point = location.Left(); point.X >= _map.LeftTop.X; point = point.Left())
            {
                if (_map[point.Down()] == GroundType.Sand)
                {
                    if (_map[point.Down().Right()] == GroundType.Clay)
                    {
                        hasWall = true;
                        break;
                    }

                    return;
                }

                if (_map[point] != GroundType.Sand)
                {
                    hasWall = true;
                    break;
                }

                leftLength++;
            }

            if (!hasWall)
            {
                return;
            }

            hasWall = false;
            var rightLength = 0;
            for (var point = location.Right(); point.X <= _map.RightBottom.X; point = point.Right())
            {
                if (_map[point.Down()] == GroundType.Sand)
                {
                    if (_map[point.Down().Left()] == GroundType.Clay)
                    {
                        hasWall = true;
                        break;
                    }

                    return;
                }

                if (_map[point] != GroundType.Sand)
                {
                    hasWall = true;
                    break;
                }

                rightLength++;
            }

            if (!hasWall)
            {
                return;
            }

            if (leftLength > 0)
            {
                _queue.Add(new SpringStep(location.Left(), FlowDirection.Left, leftLength - 1, downEntryPoint));
            }

            if (rightLength > 0)
            {
                _queue.Add(new SpringStep(location.Right(), FlowDirection.Right, rightLength - 1, downEntryPoint));
            }

            if (leftLength == 0 && rightLength == 0)
            {
                InvestigateUp(location.Up(), downEntryPoint);
            }
        }

        private void InvestigateLeft(Point fromPosition, Point downEntryPoint)
        {
            if (_map[fromPosition.Down()] == GroundType.Sand)
            {
                return;
            }

            var location = fromPosition;
            var length = 0;
            while (_map[location.Down()] == GroundType.Clay && _map[location.Left()] == GroundType.Sand)
            {
                length++;
                location = location.Left();
            }

            if (length > 0)
            {
                _queue.Add(new SpringStep(fromPosition.Left(), FlowDirection.Left, length - 1, downEntryPoint));
            }
        }

        private void InvestigateRight(Point fromPosition, Point downEntryPoint)
        {
            if (_map[fromPosition.Down()] == GroundType.Sand)
            {
                return;
            }

            var location = fromPosition;
            var length = 0;
            while (_map[location.Down()] == GroundType.Clay && _map[location.Right()] == GroundType.Sand)
            {
                length++;
                location = location.Right();
            }

            if (length > 0)
            {
                _queue.Add(new SpringStep(fromPosition.Right(), FlowDirection.Right, length - 1, fromPosition));
            }
        }
    }
}
