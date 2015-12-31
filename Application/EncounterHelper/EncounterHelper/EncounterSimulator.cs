using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterHelper
{
    public static class EncounterSimulator
    {
        public static void SimulateEncounter(List<Monster> monsters, List<PlayableCharacter> players)
        {
            var fusion = new List<IEncounterParticipant>();
            fusion.AddRange(monsters);
            fusion.AddRange(players);
            fusion = fusion.OrderByDescending(x => x.Initiative).ToList();

            foreach (var encounterParticipant in fusion)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(encounterParticipant);
                Console.WriteLine("------------------------------");
            }

        }
    }
}