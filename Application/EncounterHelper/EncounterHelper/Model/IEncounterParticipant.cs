using DmHelperGui.ModelView;

namespace EncounterHelper
{
    public abstract class IEncounterParticipant
    {
        public abstract string Name { get; set; }
        public abstract int AC { get; set; }
        public abstract int CurrentHitsPoints { get; set; }
        public abstract int Initiative { get; set; }

        public EncounterParticipantViewModel GetEncounterParticipant()
        {
            return new EncounterParticipantViewModel()
            {
                Name = Name,
                AC = AC,
                Initiative = Initiative,
                CurrentHitsPoints = CurrentHitsPoints,
                Details = GetDetails()
            };
        }

        public abstract string GetDetails();
    }
}