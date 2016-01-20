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

            var description = new StringBuilder();

            foreach (var encounterParticipant in fusion)
            {
                description.AppendLine("------------------------------");
                description.AppendLine(encounterParticipant.ToString());
                description.AppendLine("------------------------------");
            }

            var simulation = new EncounterSimulation(){EncounterDescription = description.ToString()};
            return simulation;
        }
    }
}