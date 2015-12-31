namespace EncounterHelper
{
    public class PlayableCharacter : IEncounterParticipant
    {
        public string Name { get; set; }

        public int Initiative { get; set; }

        public int AC { get; set; }

        public int PassivePerception { get; set; }

        public override string ToString()
        {
            var toString = string.Format("Name: {0}\n" +
                                         "AC: {1}"
                                         , Name, AC);
            return toString;
        } 
    }
}