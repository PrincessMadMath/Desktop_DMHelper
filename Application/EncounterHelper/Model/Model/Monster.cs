using System.Collections.Generic;
using System.Text;
using EncounterHelper.Model;

namespace EncounterHelper
{
    public class Monster : IEncounterParticipant
    {
        public override string Name { get; set; }
        public override int AC { get; set; }
        public override int CurrentHitsPoints { get; set; }
        public override int Initiative { get; set; }

        public string Description { get; set; }

        public int MaximumHitsPoints { get; set; }

        public List<DamageType> Vulnerabilities { get; set; }

        public List<DamageType> Resistances { get; set; }

        public List<DamageType> Immunities { get; set; }

        public List<Attack> Attacks { get; set; }

        public List<Spell> Spells { get; set; }

        public override string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Attacks: {listFormater(Attacks)}");
            builder.AppendLine("##########################");
            builder.AppendLine($"Spells: {listFormater(Spells)}");
            builder.AppendLine("##########################");
            builder.AppendLine($"Vulnerabilities: {listFormater(Vulnerabilities)}");
            builder.AppendLine($"Resistance: {listFormater(Resistances)}");
            builder.AppendLine($"Imminuties: {listFormater(Immunities)}");
            return builder.ToString();
        }

        private string listFormater<T>(List<T> list)
        {
            var formattedString = new StringBuilder();
            list?.ForEach(x => formattedString.AppendLine(x.ToString()));
            return formattedString.ToString();
        }

    }
}