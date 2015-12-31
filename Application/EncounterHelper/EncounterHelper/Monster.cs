using System.Collections.Generic;
using System.Text;

namespace EncounterHelper
{
    public class Monster : IEncounterParticipant
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CurrentHitsPoints { get; set; }
        public int MaximumHitsPoints { get; set; }

        public int AC { get; set; }

        public int Initiative { get; set; }

        public List<DamageType> Vulnerabilities { get; set; }

        public List<DamageType> Resistances { get; set; }

        public List<DamageType> Immunities { get; set; }

        public List<Attack> Attacks { get; set; }

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
                            "Hits Points: {3}" + "\n"  
                          //  "Attacks: {4}"
                            , Name, AC, Description, CurrentHitsPoints, attackCollection);
            return toString;
        } 
    }
}