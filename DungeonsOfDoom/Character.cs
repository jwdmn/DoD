using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Character : WorldItem
    {
        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public Character(int health, int attackDamage, char symbol) : base(symbol)
        {
            Health = health;
            AttackDamage = attackDamage;
        }
    }
}
