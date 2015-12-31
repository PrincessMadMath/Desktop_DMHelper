namespace EncounterHelper
{
    public static class MonsterFactory
    {
        public static Monster CreateMonster(MonsterBuilder encounterMonster)
        {
            var baseMonster = MonsterRepository.GetMonsterStat(encounterMonster.MonsterType);

            var name = encounterMonster.Name ?? baseMonster.Name;
            var ac = encounterMonster.AC ?? baseMonster.AC ?? 10;
            var description = encounterMonster.Description ?? baseMonster.Description;
            var attacks = encounterMonster.Attacks ?? baseMonster.Attacks;
            var resistance = encounterMonster.Resistances ?? baseMonster.Resistances;
            var immunities = encounterMonster.Immunities ?? baseMonster.Immunities;
            var vulnerabilities = encounterMonster.Vulnerabilities ?? baseMonster.Vulnerabilities;

            var newMonster = new Monster()
            {
                Name = name,
                AC = ac, 
                Description = description,
                Attacks = attacks,
                Resistances = resistance,
                Immunities = immunities,
                Vulnerabilities = vulnerabilities
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
                newMonster.MaximumHitsPoints = lifeTotal;
                newMonster.CurrentHitsPoints = lifeTotal;
            }

            // Roll initiative
            var initiativeBonus = encounterMonster.InitiativeBonus ?? baseMonster.InitiativeBonus ?? 0;
            var initiative = DiceRoller.RollDice(1, Dice.D20, initiativeBonus);
            newMonster.Initiative = initiative;

            return newMonster;
        }

    }
}