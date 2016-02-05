using EncounterHelper;

namespace Database.Factory
{
    public static class PlayerFactory
    {
        public static PlayableCharacter CreateCharacter(PlayableCharacterBuilder pcBuilder)
        {
            var newPlayer = new PlayableCharacter(){Name = pcBuilder.Name, AC = pcBuilder.AC, PassivePerception = pcBuilder.PassivePerception};
            return newPlayer;
        }
    }
}