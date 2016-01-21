using DmHelperGui.ModelView;
using EncounterHelper;

namespace DmHelperGui.ViewLogic
{
    public class EncounterManager
    {
        private EncounterManager()
        {
        }

        private static EncounterManager _instance;

        public static EncounterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EncounterManager();
                }
                return _instance;
            }
        }

        private EncounterInfoStarter _encounterInfo = new EncounterInfoStarter();

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

        public EncounterSimulation GetSimulation()
        {
            return EncounterFactory.CreateEncounter(_encounterInfo);
        }
    }
}