using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemTypeId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }


        public GameItem(int itemTypeId, string name, int price)
        {
            ItemTypeId = itemTypeId;
            Name = name;
            Price = price;
        }


        public GameItem DeepClone()
        {
            return new GameItem(ItemTypeId, Name, Price);
        }

    }
}
