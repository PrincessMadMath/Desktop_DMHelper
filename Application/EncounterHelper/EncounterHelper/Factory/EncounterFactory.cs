using System.Collections.Generic;
using DmHelperGui.ModelView;
using Helper;

namespace EncounterHelper
{
    public static class EncounterFactory
    {
        public static EncounterSimulation CreateEncounter(EncounterInfoStarter info)
        {
            return CreateEncounter(info.EncounterPath, info.PartyPath);
        }

        public static EncounterSimulation CreateEncounter(string encounterPath, string playerPath)
        {
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

            return EncounterSimulator.SimulateEncounter(monsters, players);
        }
    }
}