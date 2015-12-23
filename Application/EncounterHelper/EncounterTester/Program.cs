using System;
using EncounterHelper;
using Helper;

namespace EncounterTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Goblin Hideout
            var serializeMonsters = SimpleFileReader.ReadFile("GoblinAmbush.json");
            //var serializeMonsters = SimpleFileReader.ReadFile("PrisoOtage.json");
            //var serializeMonsters = SimpleFileReader.ReadFile("Klarg.json");

            // Cragmaw
            //var serializeMonsters = SimpleFileReader.ReadFile("Cragmaw_Entrance.json");
            //var serializeMonsters = SimpleFileReader.ReadFile("Chapelle.json");
            //var serializeMonsters = SimpleFileReader.ReadFile("Owlbear.json");
            //var serializeMonsters = SimpleFileReader.ReadFile("KingGrol.json");
            // Wave Echo Cave

            var monsters = JsonParserHelper.ParseList<Monster>(serializeMonsters);

            var serializePlayers = SimpleFileReader.ReadFile("Players.json");
            var players = JsonParserHelper.ParseList<PlayableCharacter>(serializePlayers);

            EncounterSimulator.SimulateEncounter(monsters, players);

            Console.ReadLine();
        }
    }
}
