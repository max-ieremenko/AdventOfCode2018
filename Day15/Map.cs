using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Day15
{
    internal sealed class Map
    {
        private readonly bool[,] _field;
        private readonly List<Unit> _units;

        public Map(bool[,] field, IEnumerable<Unit> units)
        {
            _field = field;
            _units = new List<Unit>(units);
            Units = new ReadOnlyCollection<Unit>(_units);
        }

        public IList<Unit> Units { get; }

        public RoundResult NexRound()
        {
            _units.Sort((x, y) => PathResolver.ComparePointsInReadingOrder(x.Location, y.Location));

            var isFullRound = true;
            var combatIsFinished = false;

            for (var i = 0; i < _units.Count; i++)
            {
                var flag = _units[i].Flag;
                var targets = _units.Where(u => u.Flag != flag).ToList();

                if (targets.Count == 0)
                {
                    isFullRound = false;
                    combatIsFinished = true;
                    break;
                }

                if (TryToAttack(ref i, targets))
                {
                }
                else if (TryToMove(i, targets))
                {
                    TryToAttack(ref i, targets);
                }
            }

            return new RoundResult(isFullRound, combatIsFinished);
        }

        public override string ToString()
        {
            var horizontal = _field.GetLength(0);
            var vertical = _field.GetLength(1);
            var text = new StringBuilder((horizontal + 2) * vertical);

            for (var y = 0; y < vertical; y++)
            {
                if (y > 0)
                {
                    text.AppendLine();
                }

                for (var x = 0; x < horizontal; x++)
                {
                    var cell = (char)(_field[x, y] ? Area.Cavern : Area.Wall);
                    var unit = _units.FirstOrDefault(i => i.Location.X == x && i.Location.Y == y);

                    if (unit != null)
                    {
                        cell = unit.Flag;
                    }

                    text.Append(cell);
                }
            }

            return text.ToString();
        }

        internal PathResolver CreatePathResolver()
        {
            return new PathResolver(_field, _units.Select(i => i.Location));
        }

        private bool TryToAttack(ref int unitIndex, IEnumerable<Unit> targets)
        {
            var unit = _units[unitIndex];

            var target = targets
                .Where(i => i.IsNeighborOf(unit.Location))
                .OrderBy(i => i.HitPoints)
                .ThenBy(i => i.Location.Y)
                .ThenBy(i => i.Location.X)
                .FirstOrDefault();

            if (target == null)
            {
                return false;
            }

            target.HitPoints -= unit.AttackPower;
            if (target.HitPoints <= 0)
            {
                var targetIndex = _units.IndexOf(target);
                _units.RemoveAt(targetIndex);

                if (targetIndex < unitIndex)
                {
                    unitIndex--;
                }
            }

            return true;
        }

        private bool TryToMove(int unitIndex, IEnumerable<Unit> targets)
        {
            var unit = _units[unitIndex];
            var pathResolver = CreatePathResolver();

            var path = targets
                .AsParallel()
                .Select(i => pathResolver.FindPath(unit.Location, i.Location))
                .Where(i => i != null)
                .OrderBy(i => i.Length)
                .ThenBy(i => i.FirstStep.Y)
                .ThenBy(i => i.FirstStep.X)
                .FirstOrDefault();

            if (path != null)
            {
                unit.Location = path.FirstStep;
                return true;
            }

            return false;
        }
    }
}
