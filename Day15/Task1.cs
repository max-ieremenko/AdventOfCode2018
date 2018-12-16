using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var map = InputParser.Parse(input);
            var history = new BattleHistory();

            RoundResult result;
            do
            {
                result = map.NexRound();
                history.NextRound(result.IsFullRound);
            }
            while (!result.CombatIsFinished);

            var hitPoints = map.Units.Sum(i => i.HitPoints);
            return history.FullRounds * hitPoints;
        }
    }
}
