using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var map = InputParser.Parse(input);
            var elfAttackPower = Unit.DefaultAttackPower + 1;

            int result;
            while ((result = TryBattle(map.Clone(), elfAttackPower)) == 0)
            {
                elfAttackPower++;
            }

            return result;
        }

        private static int TryBattle(Map map, int elfAttackPower)
        {
            var elfsCount = 0;
            foreach (var unit in map.Units.Where(i => i.Flag == (char)Area.Elf))
            {
                elfsCount++;
                unit.AttackPower = elfAttackPower;
            }

            var history = new BattleHistory();

            RoundResult result;
            do
            {
                result = map.NexRound();
                history.NextRound(result.IsFullRound);

                var test = map.Units.Count(i => i.Flag == (char)Area.Elf);
                if (test != elfsCount)
                {
                    return 0;
                }
            }
            while (!result.CombatIsFinished);

            var hitPoints = map.Units.Sum(i => i.HitPoints);
            return history.FullRounds * hitPoints;
        }
    }
}
