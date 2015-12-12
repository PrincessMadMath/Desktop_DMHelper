using Newtonsoft.Json;

namespace EncounterHelper
{
    public class PlayableCharacter : IEncounterParticipant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("initiative_bonus")]
        public int InitiativeBonus { get; set; }

        [JsonProperty("ac")]
        public int AC { get; set; }

        [JsonProperty("passive_perception")]
        public int PassivePerception { get; set; }

        public int GetInitiative()
        {
            return DiceRoller.RollDice(20) + InitiativeBonus;
        }

        public override string ToString()
        {
            var toString = string.Format("Name: {0}\n" +
                                         "AC: {1}"
                                         , Name, AC);
            return toString;
        }
    }
}