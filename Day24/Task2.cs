using System.Collections.Generic;
using System.Linq;

namespace Day24
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var battle = new Battle(InputParser.Parse(input));
            var boost = FindBoost(battle);

            ApplyBoost(battle, boost);
            return Task1.Solve(battle);
        }

        private static int FindBoost(Battle battle)
        {
            var history = new BoostHistory();

            var boostBattle = battle;
            while (!history.MinBoost.HasValue)
            {
                var boost = history.GetNext();
                boostBattle = battle.Clone();
                history.Validate(boost, TestBoost(boostBattle, boost));
            }

            return history.MinBoost.Value;
        }

        private static void ApplyBoost(Battle battle, int boost)
        {
            foreach (var group in battle.Groups.Where(i => i.Flag == GroupFlag.ImmuneSystem))
            {
                group.AttackDamage += boost;
            }
        }

        private static bool TestBoost(Battle battle, int boost)
        {
            ApplyBoost(battle, boost);

            while (!battle.IsFinished)
            {
                battle.SelectTargets();
                battle.Attack();
            }

            return battle.FlagsCount == 1 && battle.Groups[0].Flag == GroupFlag.ImmuneSystem;
        }
    }
}
