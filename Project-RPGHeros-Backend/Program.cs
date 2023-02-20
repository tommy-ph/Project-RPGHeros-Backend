using Project_RPG_Heroes.Characters;
using Project_RPGHeros_Backend.Attributes;
using Project_RPGHeros_Backend.Items;

namespace Project_RPGHeros_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Create hero objects with weapons and armor
            Mage mage1 = new Mage("Mage");
            mage1.Equip(new Weapon("Mage's weapon", 1, Slots.Weapon, WeaponTypes.Staffs, 10));
            mage1.Equip(new Armor("Armor", 2, Slots.Armor, ArmorTypes.Cloth, new HeroAttribute(1, 1, 8)));

            Ranger ranger1 = new Ranger("Ranger");
            ranger1.Equip(new Weapon("Ranger's weapom", 1, Slots.Weapon, WeaponTypes.Staffs, 9));
            ranger1.Equip(new Armor("Armor", 2, Slots.Armor, ArmorTypes.Cloth, new HeroAttribute(1, 7, 1)));

            Rogue rogue1 = new Rogue("Rogue");
            rogue1.Equip(new Weapon("Rogue's weapon", 1, Slots.Weapon, WeaponTypes.Staffs, 9));
            rogue1.Equip(new Armor("Armor", 2, Slots.Armor, ArmorTypes.Cloth, new HeroAttribute(2, 6, 1)));

            Warrior warrior1 = new Warrior("Warrior");
            warrior1.Equip(new Weapon("Warrior's weapon", 1, Slots.Weapon, WeaponTypes.Staffs, 10));
            warrior1.Equip(new Armor("Armor", 2, Slots.Armor, ArmorTypes.Cloth, new HeroAttribute(5, 2, 1)));

            // Display hero information
            Console.WriteLine(mage1.Display());
            Console.WriteLine(ranger1.Display());
            Console.WriteLine(rogue1.Display());
            Console.WriteLine(warrior1.Display());

            // Level up heroes and calculate damage
            mage1.Levelup();
            ranger1.Levelup();
            rogue1.Levelup();
            warrior1.Levelup();

            int damageGandalf = mage1.CalculateDamage();
            int damageRanger = ranger1.CalculateDamage();
            int damageRogue = rogue1.CalculateDamage();
            int damageWarrior = warrior1.CalculateDamage();

            // Display new hero information and damage
            Console.WriteLine(mage1.Display());
            Console.WriteLine(ranger1.Display());
            Console.WriteLine(rogue1.Display());
            Console.WriteLine(warrior1.Display());


        }
    }
}