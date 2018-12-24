using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day24
{
    internal static class InputParser
    {
        private const string ImmuneSystem = "Immune System:";
        private const string Infection = "Infection:";

        public static IList<Group> Parse(IEnumerable<string> input)
        {
            var result = new List<Group>();
            var flag = (GroupFlag)100;

            foreach (var line in input)
            {
                if (line.Length == 0)
                {
                    continue;
                }

                if (line.StartsWith(ImmuneSystem))
                {
                    flag = GroupFlag.ImmuneSystem;
                }
                else if (line.StartsWith(Infection))
                {
                    flag = GroupFlag.Infection;
                }
                else
                {
                    result.Add(ParserGroup(flag, line));
                }
            }

            return result;
        }

        internal static Group ParserGroup(GroupFlag flag, string line)
        {
            const string EachWith = "each with ";
            const string HitPoints = " hit points";
            const string Attack = "attack that does ";
            const string Initiative = "initiative ";

            // 17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
            var index = line.IndexOf(' ');
            var unitsCount = ParseInt(line.Substring(0, index));

            index = line.IndexOf(EachWith, StringComparison.OrdinalIgnoreCase);
            var index2 = line.IndexOf(HitPoints, index, StringComparison.OrdinalIgnoreCase);
            var unitHitPoints = ParseInt(line.Substring(index + EachWith.Length, index2 - index - EachWith.Length));

            index = line.IndexOf(Attack, StringComparison.OrdinalIgnoreCase);
            index2 = line.IndexOf(" ", index + Attack.Length + 1, StringComparison.OrdinalIgnoreCase);
            var attackDamage = ParseInt(line.Substring(index + Attack.Length, index2 - index - Attack.Length));

            index = index2;
            index2 = line.IndexOf(" ", index + 1, StringComparison.OrdinalIgnoreCase);
            var attackType = ParseAttackType(line.Substring(index + 1, index2 - index - 1));

            index = line.IndexOf(Initiative, StringComparison.OrdinalIgnoreCase);
            var initiative = ParseInt(line.Substring(index + Initiative.Length));

            var group = new Group(flag, unitsCount, unitHitPoints, attackType, attackDamage, initiative);

            ParseWeakAndImmune(group, line);
            return group;
        }

        private static void ParseWeakAndImmune(Group group, string line)
        {
            const string WeakTo = "Weak to ";
            const string ImmuneTo = "immune to ";

            var index = line.IndexOf("(", StringComparison.OrdinalIgnoreCase);
            if (index < 0)
            {
                return;
            }

            var index2 = line.IndexOf(")", index + 1, StringComparison.OrdinalIgnoreCase);

            // weak to radiation, bludgeoning
            // immune to radiation; weak to fire, cold
            var parts = line
                .Substring(index + 1, index2 - index - 1)
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim());
            foreach (var part in parts)
            {
                string types;
                ICollection<AttackType> destination;
                if (part.StartsWith(WeakTo, StringComparison.OrdinalIgnoreCase))
                {
                    types = part.Substring(WeakTo.Length);
                    destination = group.Weaknesses;
                }
                else if (part.StartsWith(ImmuneTo, StringComparison.OrdinalIgnoreCase))
                {
                    types = part.Substring(ImmuneTo.Length);
                    destination = group.Immunities;
                }
                else
                {
                    throw new NotSupportedException();
                }

                foreach (var i in types.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(ParseAttackType))
                {
                    destination.Add(i);
                }
            }
        }

        private static int ParseInt(string value)
        {
            return int.Parse(value, CultureInfo.InvariantCulture);
        }

        private static AttackType ParseAttackType(string value)
        {
            return (AttackType)Enum.Parse(typeof(AttackType), value, true);
        }
    }
}
