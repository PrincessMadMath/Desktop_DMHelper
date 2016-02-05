using System.Text;


namespace EncounterHelper
{
    public class PlayableCharacter : IEncounterParticipant
    {
        public override string Name { get; set; }
        public override int AC { get; set; }
        public override int CurrentHitsPoints { get; set; }
        public override int Initiative { get; set; }
        public int PassivePerception { get; set; }


        public override string ToString()
        {
            var toString = string.Format("Name: {0}\n" +
                                         "AC: {1}"
                                         , Name, AC);
            return toString;
        }

        public override string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Passive Perception {PassivePerception}");
            return builder.ToString();
        }

    }
}