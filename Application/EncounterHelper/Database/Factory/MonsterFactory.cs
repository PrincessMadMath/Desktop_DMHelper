using System.Collections.Generic;
using Database.Database;
using EncounterHelper;

namespace Database.Factory
{
    public static class MonsterFactory
    {
        public static Monster CreateMonster(MonsterBuilder encounterMonster)
        {
            var baseMonster = MonsterDatabase.GetMonsterStat(encounterMonster.MonsterType);

            var name = encounterMonster.Name ?? baseMonster.Name;
            var ac = encounterMonster.AC ?? baseMonster.AC ?? 10;
            var description = encounterMonster.Description ?? baseMonster.Description;
            var attacks = encounterMonster.Attacks ?? baseMonster.Attacks;
            var resistance = encounterMonster.Resistances ?? baseMonster.Resistances;
            var immunities = encounterMonster.Immunities ?? baseMonster.Immunities;
            var vulnerabilities = encounterMonster.Vulnerabilities ?? baseMonster.Vulnerabilities;

            var spellsId = new List<string>();
            spellsId.AddRange(encounterMonster.Spells ?? new List<string>());
            spellsId.AddRange(baseMonster.Spells ?? new List<string>());
            var spells = SpellDatabase.GetSpellStat(spellsId);

            var newMonster = new Monster()
            {
                Name = name,
                AC = ac,
                Description = description,
                Attacks = attacks,
                Resistances = resistance,
                Immunities = immunities,
                Vulnerabilities = vulnerabilities,
                Spells = spells
            };

            // Roll HP
            var manualHP = encounterMonster.ManualHp ?? baseMonster.ManualHp;
            if (manualHP != null)
            {
                newMonster.MaximumHitsPoints = manualHP.Value;
                newMonster.CurrentHitsPoints = manualHP.Value;
            }
            else
            {
                int diceCount = encounterMonster.HitsPointsDiceCount ?? baseMonster.HitsPointsDiceCount ?? 1;
                Dice dice = encounterMonster.HitsPointsDice ?? baseMonster.HitsPointsDice ?? Dice.D8;
                var lifeTotal = DiceRoller.RollDice(diceCount, dice, 0);
                var lifeBonus = encounterMonster.HitsPointsBonus ?? baseMonster.HitsPointsBonus ?? 0;

                newMonster.MaximumHitsPoints = lifeTotal + lifeBonus;
                newMonster.CurrentHitsPoints = lifeTotal + lifeBonus;
            }

            // Roll initiative
            var initiativeBonus = encounterMonster.InitiativeBonus ?? baseMonster.InitiativeBonus ?? 0;
            var initiative = DiceRoller.RollDice(1, Dice.D20, initiativeBonus);
            newMonster.Initiative = initiative;

            return newMonster;
        }

    }
}