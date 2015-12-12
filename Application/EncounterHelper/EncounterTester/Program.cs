using System;
using EncounterHelper;
using Helper;

namespace EncounterTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializeMonsters = SimpleFileReader.ReadFile("MonstersTest.json");
            var monsters = JsonParserHelper.ParseList<Monster>(serializeMonsters);

            var serializePlayers = SimpleFileReader.ReadFile("Players.json");
            var players = JsonParserHelper.ParseList<PlayableCharacter>(serializePlayers);

            EncounterSimulator.SimulateEncounter(monsters, players);

            Console.ReadLine();
        }
    }
}
