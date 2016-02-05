using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EncounterHelper.Model
{
    public class Spell
    {
        [JsonProperty("spell_name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("casting_time")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CastingTime CastingTime { get; set; }

        [JsonProperty("range")]
        public int Range { get; set; }

        [JsonProperty("components")]
        public string Components { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"    Name: {Name}, Level: {Level}");
            builder.AppendLine($"       Casting Time: {CastingTime}, Range: {Range}, Components: {Components}, Duration: {Duration}");
            builder.AppendLine($"       Description: {Description}");
            return builder.ToString();
        }
    }
}
