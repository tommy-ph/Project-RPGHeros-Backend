using Project_RPGHeros_Backend.Attributes;
using Project_RPG_Heroes.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Project_RPGHeros_Backend.Exceptions;

namespace Project_RPGHeros_Backend.Items
{
    public class Armor: Item
    {
        
        public ArmorTypes ArmorType { get; set; }
        public HeroAttribute ArmorAttribute { get; set; }

        public Armor(string name, int requiredLevel, Slots slot, ArmorTypes armorType, HeroAttribute armorAttribute) : base(name, requiredLevel, slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }

        public override void Equip(Hero hero)
        {
            if (!hero.ValidArmorTypes.Contains(ArmorType))
            {
                throw new InvalidArmorException($"Cannot equip {Name} because it is not a valid armor for {hero.GetType().Name}.");
            }

            if (hero.Level < RequiredLevel)
            {
                throw new InvalidArmorException($"Cannot equip {Name} because it requires level {RequiredLevel} and {hero.Name} is only level {hero.Level}.");
            }
            hero.Equipment[Slot] = this;
        }
    }
}
