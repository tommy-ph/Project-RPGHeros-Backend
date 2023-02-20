using Project_RPG_Heroes.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPGHeros_Backend.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slots Slot { get; set; }

        public Item(string nameItem, int requiredLevelItem, Slots slot)
        {
            Name = nameItem;
            RequiredLevel = requiredLevelItem;
            Slot= slot;
        }

        public abstract void Equip(Hero hero);
       
    }
}
