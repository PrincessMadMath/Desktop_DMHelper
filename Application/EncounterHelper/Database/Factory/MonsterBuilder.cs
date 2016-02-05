using System.Collections.Generic;
using EncounterHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Database.Factory
{
    public class MonsterBuilder
    {
        [JsonProperty("monster_type")]
        public string MonsterType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ennemy_count")]
        public int? EnnemyCount { get; set; }

        [JsonProperty("manual_hp", ItemConverterType = typeof(StringEnumConverter))]
        public int? ManualHp { get; set; }

        [JsonProperty("hits_points_dice", ItemConverterType = typeof(StringEnumConverter))]
        public Dice? HitsPointsDice { get; set; }

        [JsonProperty("hits_points_dice_count")]
        public int? HitsPointsDiceCount { get; set; }

        [JsonProperty("hits_points_bonus")]
        public int? HitsPointsBonus { get; set; }

        [JsonProperty("ac")]
        public int? AC { get; set; }

        [JsonProperty("initiative_bonus")]
        public int? InitiativeBonus { get; set; }

        [JsonProperty("vulnerabilities", ItemConverterType = typeof(StringEnumConverter))]
        public List<DamageType> Vulnerabilities { get; set; }

        [JsonProperty("resistances", ItemConverterType = typeof(StringEnumConverter))]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<DamageType> Resistances { get; set; }

        [JsonProperty("immunities", ItemConverterType = typeof(StringEnumConverter))]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<DamageType> Immunities { get; set; }

        [JsonProperty("attacks")]
        public List<Attack> Attacks { get; set; }

        [JsonProperty("spells")]
        public List<string> Spells { get; set; }
    }
}