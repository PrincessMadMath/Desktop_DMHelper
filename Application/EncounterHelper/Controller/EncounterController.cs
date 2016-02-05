using EncounterHelper.Model;
using EncounterHelper.Simulator;
using ViewModel.Encounter;

namespace Controller
{
    public class EncounterController
    {
        private EncounterController()
        {
        }

        public static EncounterController Instance { get; } = new EncounterController();

        private readonly EncounterInfoStarter _encounterInfo = new EncounterInfoStarter();

        public void SetPartyPath(string path)
        {
            if (path == null)
            {
                return;
            }
            _encounterInfo.PartyPath = path;
        }

        public void SetEncounterPath(string path)
        {
            if (path == null)
            {
                return;
            }
            _encounterInfo.EncounterPath = path;
        }

        public EncounterViewModel StartEncounter()
        {
            var encounter = EncounterFactory.CreateEncounter(_encounterInfo);
            return EncounterViewModel.GetViewModel(encounter);
        }
    }
}