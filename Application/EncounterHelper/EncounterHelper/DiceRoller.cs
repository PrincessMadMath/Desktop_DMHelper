using System;

namespace EncounterHelper
{
    public static class DiceRoller
    {
        private static readonly Random Random = new Random();

        public static int RollDice(int dice)
        {
            return Random.Next(1, dice);
        }

        public static int RollDice(int diceCount, int diceValue, int bonus)
        {
            int sum = 0;
            while (diceCount-- > 0)
            {
                sum += RollDice(diceValue);
            }
            return sum + bonus;
        }

        public static int RollDice(int diceCount, Dice dice, int bonus)
        {
            return RollDice(diceCount, GetDiceValue(dice), bonus);
        }

        public static int GetDiceValue(Dice dice)
        {
            int value = 0;
            switch (dice)
            {
                case Dice.D4:
                    value = 4;
                    break;
                case Dice.D6:
                    value = 6;
                    break;
                case Dice.D8:
                    value = 8;
                    break;
                case Dice.D10:
                    value = 10;
                    break;
                case Dice.D12:
                    value = 12;
                    break;
                case Dice.D20:
                    value = 20;
                    break;
                case Dice.D100:
                    value = 100;
                    break;
            }
            return value;
        }
    }
}