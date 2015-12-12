using System;

namespace EncounterHelper
{
    public static class DiceRoller
    {
        private static Random rdn = new Random();

        public static int RollDice(int dice)
        {
            return rdn.Next(1, dice);
        }
    }
}