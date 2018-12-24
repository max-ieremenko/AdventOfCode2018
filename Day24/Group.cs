using System.Collections.Generic;
using System.Diagnostics;

namespace Day24
{
    [DebuggerDisplay("{Flag} {UnitsCount}")]
    internal sealed class Group
    {
        public Group(
            GroupFlag flag,
            int unitsCount,
            int unitHitPoints,
            AttackType attackType,
            int attackDamage,
            int initiative)
        {
            Flag = flag;
            UnitHitPoints = unitHitPoints;
            AttackType = attackType;
            AttackDamage = attackDamage;
            Initiative = initiative;
            UnitsCount = unitsCount;

            Weaknesses = new HashSet<AttackType>();
            Immunities = new HashSet<AttackType>();
        }

        public GroupFlag Flag { get; }

        public int UnitsCount { get; set; }

        public int UnitHitPoints { get; }

        public AttackType AttackType { get; }

        public int AttackDamage { get; set; }

        public int Initiative { get; }

        public int EffectivePower => UnitsCount * AttackDamage;

        public ICollection<AttackType> Weaknesses { get; }

        public ICollection<AttackType> Immunities { get; }

        public Group Clone()
        {
            var group = new Group(Flag, UnitsCount, UnitHitPoints, AttackType, AttackDamage, Initiative);
            foreach (var i in Weaknesses)
            {
                group.Weaknesses.Add(i);
            }

            foreach (var i in Immunities)
            {
                group.Immunities.Add(i);
            }

            return group;
        }
    }
}
