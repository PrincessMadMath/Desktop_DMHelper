using System;
using EncounterHelper;
using Helper;

namespace EncounterTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load Monster Repository
            MonsterRepository.Load("MonsterRepository");

            EncounterFactory.CreateEncounter("Encounter/Test/GoblinTest.json", "Player/Players.json");

            Console.ReadLine();
        }
    }
}
