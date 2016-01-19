using Newtonsoft.Json;

namespace EncounterHelper
{
    public class PlayableCharacterBuilder
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("initiative_bonus")]
        public int InitiativeBonus { get; set; }

        [JsonProperty("ac")]
        public int AC { get; set; }

        [JsonProperty("passive_perception")]
        public int PassivePerception { get; set; }
    }
}