using System.Collections.Generic;
using System.Linq;
using EncounterHelper.Model;

namespace EncounterHelper.Simulator
{
    public static class EncounterSimulator
    {
        public static EncounterData SimulateEncounter(List<Monster> monsters, List<PlayableCharacter> players)
        {
            var fusion = new List<IEncounterParticipant>();
            fusion.AddRange(monsters);
            fusion.AddRange(players);
            fusion = fusion.OrderByDescending(x => x.Initiative).ToList();

            var simulation = new EncounterData(){ParticipantsList = fusion};
            return simulation;
        }
    }
}