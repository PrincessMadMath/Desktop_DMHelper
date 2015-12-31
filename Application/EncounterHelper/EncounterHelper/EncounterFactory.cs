using System.Collections.Generic;
using Helper;

namespace EncounterHelper
{
    public static class EncounterFactory
    {
        public static void CreateEncounter(string encounterPath, string playerPath)
        {
            // Goblin Hideout
            var serializeMonsters = FileHelper.ReadFile(encounterPath);
            var monsterBuilders = JsonParserHelper.ParseList<MonsterBuilder>(serializeMonsters);
            
            List<Monster> monsters = new List<Monster>();
            foreach (var monsterBuilder in monsterBuilders)
            {
                monsters.Add(MonsterFactory.CreateMonster(monsterBuilder));
            }


            var serializePlayers = FileHelper.ReadFile(playerPath);
            var playerBuilders = JsonParserHelper.ParseList<PlayableCharacterBuilder>(serializePlayers);

            List<PlayableCharacter> players = new List<PlayableCharacter>();
            foreach (var playerBuilder in playerBuilders)
            {
                players.Add(PlayerFactory.CreateCharacter(playerBuilder));
            }

            EncounterSimulator.SimulateEncounter(monsters, players);
        }
    }
}