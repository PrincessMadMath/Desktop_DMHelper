namespace EncounterHelper
{
    public static class PlayerFactory
    {
        public static PlayableCharacter CreateCharacter(PlayableCharacterBuilder pcBuilder)
        {
            var newPlayer = new PlayableCharacter(){Name = pcBuilder.Name, AC = pcBuilder.AC, PassivePerception = pcBuilder.PassivePerception};

            // Roll initiative
            var initiative = DiceRoller.RollDice(1, Dice.D20, pcBuilder.InitiativeBonus);
            newPlayer.Initiative = initiative;

            return newPlayer;
        }
    }
}