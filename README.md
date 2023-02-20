# Project-RPGHeros-Backend

## RPG Heroes Console Application
This is a console application built in .NET 6 using Visual Studio. It allows you to create and interact with different RPG heroes, level them up, equip them with items, 
and calculate their attributes and damage.

## Classes
The application has the following classes:

Hero: An abstract base class that encapsulates all shared functionality (fields and methods) for heroes.
Mage, Ranger, Rogue, and Warrior: Child classes that inherit from Hero and implement their own specific methods and properties.
HeroAttribute: A class that encapsulates the attributes of a hero (strength, dexterity, and intelligence) and has methods to add two instances together or increase one instance by a specified amount.
Item: An abstract base class that represents an item that can be equipped by a hero.
Weapon and Armor: Child classes that inherit from Item and represent different types of items that can be equipped.
InvalidWeaponException and InvalidArmorException: Custom exceptions that are thrown when a hero tries to equip an item they cannot use.

## Functionality
Here are some of the functionalities of the application:

Create a new hero by providing a name.
Level up a hero, which increases their level and attributes.
Equip a hero with a weapon or armor.
Calculate a hero's total attributes, which is the sum of their levelling attributes and all the armor attributes from their equipment.
Calculate a hero's damage, which is based on their currently equipped weapon.
Display a hero's details, including their name, level, attributes, and equipment.
