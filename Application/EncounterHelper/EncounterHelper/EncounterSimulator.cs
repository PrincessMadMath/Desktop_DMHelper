using System;
using System.Collections.Generic;

namespace EncounterHelper
{
    public static class EncounterSimulator
    {
        public static void SimulateEncounter(List<Monster> monsters, List<PlayableCharacter> players)
        {
            var fusion = new List<IEncounterParticipant>();
            fusion.AddRange(monsters);
            fusion.AddRange(players);
            fusion.Sort((x1, x2) => x2.GetInitiative().CompareTo(x1.GetInitiative()));

            foreach (var encounterParticipant in fusion)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(encounterParticipant);
                Console.WriteLine("------------------------------");
            }

        }
    }
}