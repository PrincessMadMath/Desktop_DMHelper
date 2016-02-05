using EncounterHelper;

namespace ViewModel.Participant
{
    public class EncounterParticipantViewModel
    {
        public string Name { get; set; }
        public int AC { get; set; }
        public int CurrentHitsPoints { get; set; }
        public int Initiative { get; set; }

        // Transform to real side windows
        public string Details { get; set; }

        public static EncounterParticipantViewModel GetViewModel(IEncounterParticipant participant)
        {
            return new EncounterParticipantViewModel()
            {
                Name = participant.Name,
                AC = participant.AC,
                Initiative = participant.Initiative,
                CurrentHitsPoints = participant.CurrentHitsPoints,
                Details = participant.GetDetails()
            };
        }

    }
}