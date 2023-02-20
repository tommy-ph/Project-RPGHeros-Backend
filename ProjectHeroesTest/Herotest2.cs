using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_RPG_Heroes.Characters;
using Project_RPGHeros_Backend.Items;
using Project_RPGHeros_Backend;
using System.Threading;
using Project_RPGHeros_Backend.Attributes;

namespace ProjectHeroesTest
{
    public class Herotest2
    {
        Weapon commonAxe = new Weapon("Common Axe", 1, Slots.Weapon, WeaponTypes.Bows, 2);

        Armor commonPlateChest = new Armor("Common Plate Chest", 1, Slots.Body, ArmorTypes.Plate, new HeroAttribute(1, 0, 0));

        Warrior warrior = new Warrior("Warrior", 1, new HeroAttribute(1, 1, 1));

        public Warrior Warrior { get => warrior; set => warrior = value; }

        [Fact]
        public void CalculateDamage_NoWeaponEquipped_ReturnsExpectedDamage()
        {
            // Arrange
            var warrior = new Warrior("John");
            warrior.Level = 1;

            // Act
            var expectedDamage = 23 * (1 + (warrior.Level * 1 / 100));
            var actualDamage = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void CalculateDamageWithValidWeaponEquipped()
        {
            // Arrange
            warrior.LevelAttributes.Strength = 10;
            warrior.LevelAttributes.Dexterity = 12;
            warrior.Equip(commonAxe);

            // Calculate expected damage based on the warrior's attributes and weapon
            int expectedDamage = (int)(warrior.LevelAttributes.Strength * 3 + warrior.LevelAttributes.Dexterity + commonAxe.Damage);

            // Act
            int actualDamage = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expectedDamage, actualDamage);
        }


        [Fact]
        public void CalculateWithValidWeaponAndArmorEquipped()
        {
            warrior.Equip(commonPlateChest);
            double expectedDamage = 27 * (1 + ((warrior.Level * 5 + warrior.LevelAttributes.Strength) / 100));
            double actualDamage = warrior.CalculateDamage();
            Assert.Equal(expectedDamage, actualDamage);

        }

        [Fact]
        public void TestWarriorInitialization()
        {
            // Arrange
            string expectedName = "Conan";
            int expectedLevel = 1;
            int expectedStrength = 5;
            int expectedDexterity = 2;
            int expectedIntelligence = 1;

            // Act
            Warrior warrior = new Warrior(expectedName);

            // Assert
            Assert.Equal(expectedName, warrior.Name);
            Assert.Equal(expectedLevel, warrior.Level);
            Assert.Equal(expectedStrength, warrior.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, warrior.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, warrior.LevelAttributes.Intelligence);
        }

        [Fact]
        public void TestHeroLevelUp()
        {
            // Arrange
            string heroName = "Conan";
            HeroAttribute attributes = new HeroAttribute(5, 3, 1);
            int initialLevel = 1;
            int expectedLevel = 2;

            Warrior warrior = new Warrior(heroName, attributes, initialLevel);

            // Act
            warrior.Levelup();

            // Assert
            Assert.Equal(expectedLevel, warrior.Level);
            Assert.Equal(8, warrior.LevelAttributes.Strength);
            Assert.Equal(4, warrior.LevelAttributes.Dexterity);
            Assert.Equal(2, warrior.LevelAttributes.Intelligence);
        }

        [Fact]
        public void TestHeroNoWeaponDamage()
        {
            // Arrange
            string heroName = "Conan";
            HeroAttribute attributes = new HeroAttribute(5, 3, 1);
            int heroLevel = 23;

            Warrior warrior = new Warrior(heroName, attributes, heroLevel);

            // Act
            int damage = warrior.CalculateDamage();

            // Assert
            Assert.Equal(23, damage);
        }

        [Fact]
        public void TestHeroWeaponDamage()
        {
            // Arrange
            string heroName = "Conan";
            HeroAttribute attributes = new HeroAttribute(5, 3, 1);
            int heroLevel = 1;
            Weapon weapon = new Weapon("Common Axe", 1, Slots.Weapon, WeaponTypes.Staffs, 2);

            Warrior warrior = new Warrior(heroName, attributes, heroLevel);

            // Act
            warrior.Equip(weapon);
            int damage = warrior.CalculateDamage();

            // Assert
            Assert.Equal(23, damage);
        }

    }
}
