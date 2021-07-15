using Engine.Models;
using System;

namespace Engine.Factories
{
    internal static class MonstersFactory
    {
        internal static Monster CreateMonsterById(int id)
        {
            Monster createdMonster;

            switch (id)
            {
                case 1:
                    createdMonster  = new Monster("Snake", "Snake.png", 4, 4, 5, 1);

                    AddLootToMonster(createdMonster, new ItemQuantity(9001, 1), 25);
                    AddLootToMonster(createdMonster, new ItemQuantity(9002, 1), 75);

                    break;

                case 2:
                    createdMonster = new Monster("Rat", "Rat.png", 5, 5, 5, 1);

                    AddLootToMonster(createdMonster, new ItemQuantity(9003, 1), 25);
                    AddLootToMonster(createdMonster, new ItemQuantity(9004, 1), 75);

                    break;

                case 3:
                    createdMonster = new Monster("Giant Spider", "GiantSpider.png", 10, 10, 10, 3);

                    AddLootToMonster(createdMonster, new ItemQuantity(9005, 1), 25);
                    AddLootToMonster(createdMonster, new ItemQuantity(9006, 1), 75);

                    break;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", id));
            }

            return createdMonster;
        }

        private static void AddLootToMonster(Monster monster, ItemQuantity itemQuantity, int percentage)
        {
            if(RandomNumberGenerator.NumberBetween(0, 100) <= percentage)
            {
                monster.Inventory.Add(itemQuantity);
            }
        }
    }
}
