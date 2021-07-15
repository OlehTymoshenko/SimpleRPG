using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }


        public Weapon(int itemTypeId, string name, int price, int minDamage, int maxDamage) 
            : base(itemTypeId, name, price)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public new Weapon DeepClone()
        {
            return new Weapon(ItemTypeId, Name, Price, MinDamage, MaxDamage);
        }
    }
}
