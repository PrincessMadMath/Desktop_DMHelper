using System.Collections.Generic;
using System.Linq;
using EncounterHelper.Model;
using ViewModel.Participant;

namespace ViewModel.Encounter
{
    public class EncounterViewModel
    {
        public List<EncounterParticipantViewModel> ParticipantsList { get; set; }

        public static EncounterViewModel GetViewModel(EncounterData data)
        {
            var list =
                data.ParticipantsList.Select(EncounterParticipantViewModel.GetViewModel).ToList();

            return new EncounterViewModel() {ParticipantsList = list};
        }
    }
}