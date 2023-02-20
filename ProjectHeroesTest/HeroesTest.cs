using Project_RPG_Heroes.Characters;
using Project_RPGHeros_Backend.Items;
using System.Threading;
using Project_RPGHeros_Backend.Attributes;


namespace ProjectHeroesTest
{
    public class HeroesTest
    {
      
        [Fact]
        public void TestHeroCreation()
        {
            Warrior warrior = new Warrior("Warrior");
            Assert.Equal(5, warrior.LevelAttributes.Strength);
            Assert.Equal(2, warrior.LevelAttributes.Dexterity);
            Assert.Equal(1, warrior.LevelAttributes.Intelligence);

        }
        [Fact]
        public void testHerolevelup()
        {
            Warrior warrior = new Warrior("Warrior");
            warrior.Levelup();
            Assert.Equal(8, warrior.LevelAttributes.Strength);
            Assert.Equal(4, warrior.LevelAttributes.Dexterity);
            Assert.Equal(2, warrior.LevelAttributes.Intelligence);
        }

        [Fact]
        public void Equip_ValidArmor_EquipsArmorToHero()
        {
            // Arrange
            var hero = new Warrior("Aragorn");
            hero.Level = 5; 
            var heroAttribute = new HeroAttribute { Intelligence = 5 }; 
            var armor = new Armor("Chainmail", 5, Slots.Weapon, ArmorTypes.Plate, heroAttribute); 

            // Act
            armor.Equip(hero);

            // Assert
            Assert.Equal(armor, hero.Equipment[Slots.Weapon]);
        }

        [Fact]
        public void Equip_ValidWeaponTypeAndLevel_EquipsWeapon()
        {
            // Arrange
            var hero = new Warrior("Aragorn");
            hero.Level = 5;
            var weapon = new Weapon("Sword", requiredLevel: 5, slot: Slots.Weapon, weaponType: WeaponTypes.Swords, damage: 10);

            // Act
            weapon.Equip(hero);

            // Assert
            Assert.Equal(weapon, hero.Equipment[Slots.Weapon]);
        }

    }


}
