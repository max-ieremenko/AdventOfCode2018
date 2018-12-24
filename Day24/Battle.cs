using System;
using System.Collections.Generic;
using System.Linq;

namespace Day24
{
    internal sealed partial class Battle
    {
        private readonly List<AttackSelection> _attacks;

        public Battle(IEnumerable<Group> groups)
        {
            Groups = groups.ToList();
            _attacks = new List<AttackSelection>();
        }

        public IList<Group> Groups { get; }

        public int FlagsCount => Groups.Select(i => i.Flag).Distinct().Count();

        public bool IsFinished { get; private set; }

        public void SelectTargets()
        {
            _attacks.Clear();
            var underAttack = new HashSet<Group>();

            var order = Groups.OrderByDescending(i => i.EffectivePower).ThenByDescending(i => i.Initiative);
            foreach (var group in order)
            {
                var selection = Groups
                    .Where(i => !underAttack.Contains(i))
                    .Select(i => new AttackSelection(group, i))
                    .Where(i => i.InitialDamage > 0)
                    .OrderByDescending(i => i.InitialDamage)
                    .ThenByDescending(i => i.Defender.EffectivePower)
                    .ThenByDescending(i => i.Defender.Initiative)
                    .FirstOrDefault();

                if (selection.Attacking != null)
                {
                    _attacks.Add(selection);
                    underAttack.Add(selection.Defender);
                }
            }
        }

        public void Attack()
        {
            var atLeastOneDamage = false;

            var order = _attacks.OrderByDescending(i => i.Attacking.Initiative);
            foreach (var selection in order)
            {
                if (selection.Attacking.UnitsCount == 0)
                {
                    continue;
                }

                var damage = selection.GetDamage();
                var unitsCount = damage / selection.Defender.UnitHitPoints;

                if (unitsCount > 0)
                {
                    atLeastOneDamage = true;
                    selection.Defender.UnitsCount = Math.Max(0, selection.Defender.UnitsCount - unitsCount);

                    if (selection.Defender.UnitsCount == 0)
                    {
                        Groups.Remove(selection.Defender);
                    }
                }
            }

            IsFinished = !atLeastOneDamage;
        }

        public Battle Clone()
        {
            return new Battle(Groups.Select(i => i.Clone()));
        }
    }
}
