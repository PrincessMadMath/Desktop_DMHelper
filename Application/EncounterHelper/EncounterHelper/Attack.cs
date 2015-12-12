using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EncounterHelper
{
    public class Attack
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("damage_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DamageType DamageType { get; set; }

        [JsonProperty("damage_roll")]
        public string DamageRoll { get; set; }

        public override string ToString()
        {
            return string.Format("    Name : {0} || Type : {1} || DamageRoll : {2}", Name, DamageType, DamageRoll);
        }
    }
}