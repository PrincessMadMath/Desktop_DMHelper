using Database.Database;

namespace Controller
{
    public class DatabaseController
    {
        private DatabaseController()
        {
        }

        public static DatabaseController Instance { get; } = new DatabaseController();

        public void LoadSpell(string path)
        {
            SpellDatabase.Load(path);
        }

        public void LoadMonster(string path)
        {
            MonsterDatabase.Load(path);
        }
    }
}