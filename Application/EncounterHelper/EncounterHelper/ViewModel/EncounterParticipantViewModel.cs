using System.Security.AccessControl;

namespace DmHelperGui.ModelView
{
    public class EncounterParticipantViewModel
    {
        public string Name { get; set; }
        public int AC { get; set; }
        public int CurrentHitsPoints { get; set; }
        public int Initiative { get; set; }

        // Transform to real side windows
        public string Details { get; set; }
    }
}