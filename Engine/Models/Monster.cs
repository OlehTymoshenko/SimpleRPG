using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;

        public string Name { get; private set; }

        public string ImageName { get; set; }

        public int MaximumHitPoints { get; private set; }

        public int HitPoints
        {
            get { return _hitPoints; }

            internal set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int RewardExperiencePoints { get; private set; }

        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; } = new ObservableCollection<ItemQuantity>();

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }


        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int minDamage, int maxDamage,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = $"pack://application:,,,/Engine;component/Images/Monsters/{imageName}";
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
        }
    }
}
