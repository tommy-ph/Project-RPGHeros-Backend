using Project_RPGHeros_Backend.Attributes;
using Project_RPGHeros_Backend.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG_Heroes.Characters
{
    public class Warrior : Hero
    {
        private HeroAttribute attributes;
        private int heroLevel;
        private int v;
        private HeroAttribute heroAttribute;

       

        public Warrior(string name) : base(name)
        {
            HeroAttribute heroAttribute = new HeroAttribute();

            ValidWeaponTypes = new List<WeaponTypes> { WeaponTypes.Axes, WeaponTypes.Hammers, WeaponTypes.Swords };
            ValidArmorTypes = new List<ArmorTypes> { ArmorTypes.Mail, ArmorTypes.Plate };
            DamagingAttribute = GetTotalAttributes().Strength = 5;
            DamagingAttribute = GetTotalAttributes().Dexterity = 2;
            DamagingAttribute = GetTotalAttributes().Intelligence = 1;
            DamagingAttribute = LevelAttributes.Strength;
            EquippedWeapon = new Weapon("Basic Axes", 1, Slots.Weapon, WeaponTypes.Axes, 1);
        }

        public Warrior(string name, HeroAttribute attributes, int heroLevel) : this(name)
        {
            this.attributes = attributes;
            this.heroLevel = heroLevel;
        }

        public Warrior(string name, int v, HeroAttribute heroAttribute) : this(name)
        {
            this.v = v;
            this.heroAttribute = heroAttribute;
        }

        public override void Levelup()
        {

            Level++;
            HeroAttribute attributeIncrease = new HeroAttribute(3, 2, 1);
            LevelAttributes = LevelAttributes.IncreaseBy(attributeIncrease);
            DamagingAttribute = GetTotalAttributes().Intelligence;
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

                if (EquippedWeapon.WeaponType == WeaponTypes.Axes)
                {
                    damage += totalAttributes.Strength * 4;
                }
            }

            double baseDamage = 1 * (1 + (Level * 5 / 100.0));
            double totalDamage = baseDamage + damage;

            return (int)(totalDamage * (1 + ((double)DamagingAttribute / 100)));
        }

    }
}
