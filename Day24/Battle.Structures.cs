using System.Diagnostics;

namespace Day24
{
    internal partial class Battle
    {
        [DebuggerDisplay("{Attacking.Flag} => {Defender.Flag}: {InitialDamage}")]
        private struct AttackSelection
        {
            public AttackSelection(Group attacking, Group defender)
            {
                Attacking = attacking;
                Defender = defender;
                InitialDamage = CalculateDamage(attacking, defender);
            }

            public Group Attacking { get; }

            public Group Defender { get; }

            public int InitialDamage { get; }

            public int GetDamage() => CalculateDamage(Attacking, Defender);

            private static int CalculateDamage(Group attacking, Group defender)
            {
                if (attacking.Flag == defender.Flag)
                {
                    return 0;
                }

                if (defender.Immunities.Contains(attacking.AttackType))
                {
                    return 0;
                }

                var damage = attacking.EffectivePower;
                if (defender.Weaknesses.Contains(attacking.AttackType))
                {
                    damage *= 2;
                }

                return damage;
            }
        }
    }
}
