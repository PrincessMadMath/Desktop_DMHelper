using System;
using System.Collections.Generic;
using EncounterHelper.Model;
using Helper;

namespace Database.Database
{
    public static class SpellDatabase
    {
        private static readonly Dictionary<string, Spell> Database = new Dictionary<string, Spell>();

        public static void Load(string directoryPath)
        {
            var filePaths = FileHelper.GetAllFilesInDirectoryAndSubDirectories(directoryPath, "*_s.json");
            foreach (var filePath in filePaths)
            {
                var serializeString = FileHelper.ReadFile(filePath);
                var spell = JsonParserHelper.ParseSingleton<Spell>(serializeString);
                if (spell != null)
                {
                    if (spell.Name == null)
                    {
                        Console.WriteLine("A spell is missing a name");
                        continue;
                    }
                    Database.Add(spell.Name, spell);
                }

            }
        }

        public static List<Spell> GetSpellStat(List<string> spellsId)
        {
            var spells = new List<Spell>();

            foreach (var spellId in spellsId)
            {
                Spell spell;
                if (Database.TryGetValue(spellId, out spell))
                {
                    spells.Add(spell);
                }
            }

            return spells;
        }
    }
}