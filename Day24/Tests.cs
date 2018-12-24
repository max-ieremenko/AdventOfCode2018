using System;
using NUnit.Framework;
using Shouldly;

namespace Day24
{
    [TestFixture]
    public class Tests
    {
        private const string Example = @"
Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4";

        [Test]
        public void Task1Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task1.Solve(input).ShouldBe(5216);
        }

        [Test]
        public void Task2Solve()
        {
            var input = Example.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task2.Solve(input).ShouldBe(51);
        }

        [Test]
        [TestCase("17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2", 17, 5390, 4507, AttackType.Fire, 2, new[] { AttackType.Radiation, AttackType.Bludgeoning }, new AttackType[0])]
        [TestCase("4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4", 4485, 2961, 12, AttackType.Slashing, 4, new[] { AttackType.Fire, AttackType.Cold }, new[] { AttackType.Radiation })]
        [TestCase("6929 units each with 51693 hit points with an attack that does 13 slashing damage at initiative 5", 6929, 51693, 13, AttackType.Slashing, 5, new AttackType[0], new AttackType[0])]
        public void ParseGroup(string definition, int unitsCount, int unitHitPoints, int attackDamage, AttackType attackType, int initiative, AttackType[] weaknesses, AttackType[] immunities)
        {
            var group = InputParser.ParserGroup(GroupFlag.Infection, definition);

            group.Flag.ShouldBe(GroupFlag.Infection);
            group.UnitsCount.ShouldBe(unitsCount);
            group.UnitHitPoints.ShouldBe(unitHitPoints);
            group.AttackDamage.ShouldBe(attackDamage);
            group.AttackType.ShouldBe(attackType);
            group.Initiative.ShouldBe(initiative);
            group.Weaknesses.ShouldBe(weaknesses);
            group.Immunities.ShouldBe(immunities);
        }

        [Test]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(999)]
        [TestCase(2123)]
        [TestCase(2)]
        public void BoostHistoryTest(int expected)
        {
            var history = new BoostHistory();
            while (!history.MinBoost.HasValue)
            {
                var next = history.GetNext();
                history.Validate(next, next >= expected);
            }

            history.MinBoost.ShouldBe(expected);
        }
    }
}
