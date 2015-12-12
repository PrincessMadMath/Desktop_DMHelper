using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EncounterHelper
{
    public class Monster : IEncounterParticipant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hits_points")]
        public string HitsPoints { get; set; }

        [JsonProperty("ac")]
        public int AC { get; set; }

        [JsonProperty("initiative_bonus")]
        public int InitiativeBonus { get; set; }

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

        public int GetInitiative()
        {
            return DiceRoller.RollDice(20) + InitiativeBonus;
        }

        public override string ToString()
        {
            StringBuilder attackCollection = new StringBuilder("\n");
            if (Attacks != null)
            {
                Attacks.ForEach(x => attackCollection.AppendLine(x.ToString()));
            }

            var toString = string.Format(
                            "Name: {0}" + "\n" +
                            "AC: {1}" + "\n" + 
                            "Description: {2}" + "\n" + 
                            "Hits Points: {3}" + "\n" + 
                            "Attacks: {4}" + "\n"
                            , Name, AC, Description, HitsPoints, attackCollection);
            return toString;
        }
    }
}