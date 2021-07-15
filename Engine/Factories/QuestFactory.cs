using Engine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items need to complete the quest, and its reward items
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));


            _quests.Add(new Quest()
            {
                ID = 1,
                Name = "Clear the herb garden",
                Description = "Defeat the snakes in the Herbalist's garden",
                ItemsToComplete = itemsToComplete,
                RewardExpPoints = 25,
                RewardGold = 10,
                RewardItems = rewardItems
            });
        }

        internal static Quest GetQuestById(int id)
        {
            return _quests.FirstOrDefault(q => q.ID == id);
        }
    }
}
