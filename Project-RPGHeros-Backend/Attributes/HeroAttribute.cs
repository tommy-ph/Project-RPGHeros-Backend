using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPGHeros_Backend.Attributes
{
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public HeroAttribute()
        {
        }

        public static HeroAttribute operator +(HeroAttribute a, HeroAttribute b)
        {
            return new HeroAttribute(a.Strength + b.Strength, a.Dexterity + b.Dexterity, a.Intelligence + b.Intelligence);
        }

        public HeroAttribute Add(HeroAttribute OtherHeroes)
        {
            return new HeroAttribute(
                Strength + OtherHeroes.Strength,
                Dexterity + OtherHeroes.Dexterity,
                Intelligence + OtherHeroes.Intelligence
                );
        }
       

        // Method to increase a HeroAttribute instance by a specified amount
        public HeroAttribute IncreaseBy(HeroAttribute other)
        {
            return new HeroAttribute(
                 Strength += other.Strength,
                 Dexterity += other.Dexterity,
                 Intelligence += other.Intelligence
                );
           
        }
    }
}
