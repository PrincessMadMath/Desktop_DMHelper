using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DmHelperGui.ModelView;

namespace EncounterHelper
{
    public static class EncounterSimulator
    {
        public static EncounterSimulation SimulateEncounter(List<Monster> monsters, List<PlayableCharacter> players)
        {
            var fusion = new List<IEncounterParticipant>();
            fusion.AddRange(monsters);
            fusion.AddRange(players);
            fusion = fusion.OrderByDescending(x => x.Initiative).ToList();

            var participants = fusion.Select(encounterParticipant => encounterParticipant.GetEncounterParticipant()).ToList();

            var simulation = new EncounterSimulation(){ParticipantsList = participants};
            return simulation;
        }
    }
}