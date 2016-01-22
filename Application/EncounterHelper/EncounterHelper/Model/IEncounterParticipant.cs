using DmHelperGui.ModelView;

namespace EncounterHelper
{
    public interface IEncounterParticipant
    {
        int Initiative { get; }
        EncounterParticipant GetEncounterParticipant();
    }
}