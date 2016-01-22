using DmHelperGui.ModelView;

namespace EncounterHelper
{
    public class PlayableCharacter : IEncounterParticipant
    {
        public string Name { get; set; }

        public int Initiative { get; set; }

        public int AC { get; set; }

        public int PassivePerception { get; set; }

        public EncounterParticipant GetEncounterParticipant()
        {
            return new EncounterParticipant()
            {
                Name = Name,
                AC = AC,
                Initiative = Initiative
            };
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