using Project_RPGHeros_Backend.Attributes;
using Project_RPGHeros_Backend.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG_Heroes.Characters
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            ValidWeaponTypes = new List<WeaponTypes> { WeaponTypes.Bows};
            ValidArmorTypes = new List<ArmorTypes> { ArmorTypes.Leather, ArmorTypes.Mail};
            DamagingAttribute = GetTotalAttributes().Strength = 1;
            DamagingAttribute = GetTotalAttributes().Dexterity = 7;
            DamagingAttribute = GetTotalAttributes().Intelligence = 1;
            DamagingAttribute = LevelAttributes.Dexterity;
            EquippedWeapon = new Weapon("Basic Bows", 1, Slots.Weapon, WeaponTypes.Bows, 1); 
        }

        public override void Levelup()
        {

            Level++;
            HeroAttribute attributeIncrease = new HeroAttribute(1, 5, 1);
            LevelAttributes = LevelAttributes.IncreaseBy(attributeIncrease);
            DamagingAttribute = GetTotalAttributes().Dexterity;
        }

        public override void Equip(Item item)
        {
            if (item is Weapon)
            {
                if (!ValidWeaponTypes.Contains((item as Weapon).WeaponType))
                {
                    Console.WriteLine("This weapon is invalid for Mage");
                    return;
                }
                else if (!ValidArmorTypes.Contains((item as Armor).ArmorType))
                {
                    Console.WriteLine("This armor is invalid for Mage");
                    return;
                }
            }
            Equipment[item.Slot] = item;
        }

        public override int CalculateDamage()
        {
            HeroAttribute totalAttributes = GetTotalAttributes();
            double damage = 0;

            if (EquippedWeapon != null)
            {
                damage = EquippedWeapon.Damage;

                if (EquippedWeapon.WeaponType == WeaponTypes.Bows)
                {
                    damage += totalAttributes.Dexterity * 4;
                }
            }

            double baseDamage = 1 * (1 + (Level * 5 / 100.0));
            double totalDamage = baseDamage + damage;

            return (int)(totalDamage * (1 + ((double)DamagingAttribute / 100)));
        }

    }
}
