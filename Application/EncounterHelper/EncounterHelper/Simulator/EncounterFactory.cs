using System.Collections.Generic;
using Database.Factory;
using EncounterHelper.Model;
using Helper;

namespace EncounterHelper.Simulator
{
    public static class EncounterFactory
    {
        public static EncounterData CreateEncounter(EncounterInfoStarter info)
        {
            return CreateEncounter(info.EncounterPath, info.PartyPath);
        }

        public static EncounterData CreateEncounter(string encounterPath, string playerPath)
        {
            var serializeMonsters = FileHelper.ReadFile(encounterPath);
            var monsterBuilders = JsonParserHelper.ParseList<MonsterBuilder>(serializeMonsters);

            List<Monster> monsters = new List<Monster>();
            foreach (var monsterBuilder in monsterBuilders)
            {
                var ennemyCount = monsterBuilder.EnnemyCount ?? 1;
                for (int i = 0; i < ennemyCount; ++i)
                {
                    monsters.Add(MonsterFactory.CreateMonster(monsterBuilder));
                }
            }

            var serializePlayers = FileHelper.ReadFile(playerPath);
            var playerBuilders = JsonParserHelper.ParseList<PlayableCharacterBuilder>(serializePlayers);

            List<PlayableCharacter> players = new List<PlayableCharacter>();
            foreach (var playerBuilder in playerBuilders)
            {
                var player = PlayerFactory.CreateCharacter(playerBuilder);
                
                // Roll initiative
                var initiative = DiceRoller.RollDice(1, Dice.D20, playerBuilder.InitiativeBonus);
                player.Initiative = initiative;
                players.Add(player);
            }

            return EncounterSimulator.SimulateEncounter(monsters, players);
        }
    }
}