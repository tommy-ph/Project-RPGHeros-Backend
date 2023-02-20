using Project_RPGHeros_Backend.Exceptions;
using Project_RPGHeros_Backend.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_RPGHeros_Backend.Items;

namespace Project_RPG_Heroes.Characters
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public double BaseDamage { get; private set; } = 1;
        public double DamagingAttribute { get; protected set; }
        public List<Hero> Characters { get; set; }
        public HeroAttribute LevelAttributes { get; set; }
        public Dictionary<Slots,Item> Equipment { get; set; } 
        public List<WeaponTypes> ValidWeaponTypes { get; set; } 
        public List<ArmorTypes> ValidArmorTypes { get; set; }
        public Weapon EquippedWeapon { get; set; }
        

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            LevelAttributes = new HeroAttribute(0, 0, 0);
            Equipment = new Dictionary<Slots, Item>
            {
                {Slots.Head, null},
                {Slots.Body, null},
                {Slots.Legs, null },
                {Slots.Weapon, null}
            };
            ValidWeaponTypes = new List<WeaponTypes>();
            ValidArmorTypes = new List<ArmorTypes>();
          
        }

        public abstract void Levelup();

        public virtual void Equip(Item item)
        {
            if (Level < item.RequiredLevel)
            {
                throw new ArgumentException($"Cannot equip {item.Name}, required level is {item.RequiredLevel}");
            }

            if (item is Weapon weapon)
            {
                EquipWeapon(weapon);
            }
            else if (item is Armor armor)
            {
                EquipArmor(armor);
            }
            else
            {
                throw new ArgumentException($"Cannot equip {item.Name}, unknown item type");
            }
        }

        private void EquipWeapon(Weapon weapon)
        {
            switch (this)
            {
                case Mage mage:
                    if (mage.ValidWeaponTypes.Contains(weapon.WeaponType))
                    {
                        Equipment[Slots.Weapon] = weapon;
                    }
                    else
                    {
                        throw new InvalidWeaponException($"Mage cannot equip {weapon.Name}");
                    }
                    break;
                case Ranger ranger:
                    if (ranger.ValidWeaponTypes.Contains(weapon.WeaponType))
                    {
                        Equipment[Slots.Weapon] = weapon;
                    }
                    else
                    {
                        throw new InvalidWeaponException($"Ranger cannot equip {weapon.Name}");
                    }
                    break;
                case Rogue rogue:
                    if (rogue.ValidWeaponTypes.Contains(weapon.WeaponType))
                    {
                        Equipment[Slots.Weapon] = weapon;
                    }
                    else
                    {
                        throw new InvalidWeaponException($"Rogue cannot equip {weapon.Name}");
                    }
                    break;
                case Warrior warrior:
                    if (warrior.ValidWeaponTypes.Contains(weapon.WeaponType))
                    {
                        Equipment[Slots.Weapon] = weapon;
                    }
                    else
                    {
                        throw new InvalidWeaponException($"Warrior cannot equip {weapon.Name}");
                    }
                    break;
                default:
                    throw new ArgumentException($"Cannot equip {weapon.Name}, unknown hero type");
            }
        }

        private void EquipArmor(Armor armor)
        {
            switch (this)
            {
                case Mage mage:
                    if (mage.ValidArmorTypes.Contains(armor.ArmorType))
                    {
                        Equipment[Slots.Armor] = armor;
                    }
                    else
                    {
                        throw new InvalidArmorException($"Mage cannot equip {armor.Name}");
                    }
                    break;
                case Ranger ranger:
                    if (ranger.ValidArmorTypes.Contains(armor.ArmorType))
                    {
                        Equipment[Slots.Armor] = armor;
                    }
                    else
                    {
                        throw new InvalidArmorException($"Ranger cannot equip {armor.Name}");
                    }
                    break;
                case Rogue rogue:
                    if (rogue.ValidArmorTypes.Contains(armor.ArmorType))
                    {
                        Equipment[Slots.Armor] = armor;
                    }
                    else
                    {
                        throw new InvalidArmorException($"Rogue cannot equip {armor.Name}");
                    }
                    break;
                case Warrior warrior:
                    if (warrior.ValidArmorTypes.Contains(armor.ArmorType))
                    {
                        Equipment[Slots.Armor] = armor;
                    }
                    else
                    {
                        throw new InvalidArmorException($"Warrior cannot equip {armor.Name}");
                    }
                    break;
                default:
                    throw new ArgumentException($"Cannot equip {armor.Name}, unknown hero type");
            }
        }

        public virtual int CalculateDamage()
        {
            HeroAttribute totalAttributes = GetTotalAttributes();   

            return (int)(EquippedWeapon.Damage * (1 + ((double)DamagingAttribute / 100)));
        }

        public virtual HeroAttribute GetTotalAttributes()
        {
            HeroAttribute totalAttributes = LevelAttributes;

            if (Equipment[Slots.Head] is Armor head)
            {
                totalAttributes += head.ArmorAttribute;
            }

            if (Equipment[Slots.Body] is Armor body)
            {
                totalAttributes += body.ArmorAttribute;
            }

            if (Equipment[Slots.Legs] is Armor legs)
            {
                totalAttributes += legs.ArmorAttribute;
            }

            return totalAttributes;
        }

        public string Display()
        {
            HeroAttribute totalAttributes = GetTotalAttributes();
            int damage = CalculateDamage();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Level: {Level}");
            stringBuilder.AppendLine($"Total Strength: {totalAttributes.Strength}");
            stringBuilder.AppendLine($"Total Dexterity: {totalAttributes.Dexterity}");
            stringBuilder.AppendLine($"Total Intelligence: {totalAttributes.Intelligence}");
            stringBuilder.AppendLine($"Damage: {damage}");

            return stringBuilder.ToString();
        }
    }
}
