using System.Collections.Generic;
using System.Linq;

namespace Day24
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var battle = new Battle(InputParser.Parse(input));
            return Solve(battle);
        }

        internal static int Solve(Battle battle)
        {
            while (battle.FlagsCount > 1)
            {
                battle.SelectTargets();
                battle.Attack();
            }

            var unitsCount = battle.Groups.Sum(i => i.UnitsCount);
            return unitsCount;
        }
    }
}
