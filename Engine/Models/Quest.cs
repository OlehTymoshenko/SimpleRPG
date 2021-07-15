using System.Collections.Generic;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ItemQuantity> ItemsToComplete { get; set; }

        public int RewardGold { get; set; }

        public int RewardExpPoints { get; set; }

        public List<ItemQuantity> RewardItems { get; set; }

        public Quest() { }

        public Quest(int id, string name, string description, List<ItemQuantity> itemsToComplete,
            int rewardGold, int rewardExpPoints, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemsToComplete = itemsToComplete;
            RewardGold = rewardGold;
            RewardExpPoints = rewardExpPoints;
            RewardItems = rewardItems;
        }

    }
}
