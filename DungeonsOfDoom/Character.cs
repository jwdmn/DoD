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
        public string Name { get; set; }

        public Character(int health, int attackDamage, char symbol, string name) : base(symbol)
        {
            Health = health;
            AttackDamage = attackDamage;
            Name = name;
        }

        public virtual string Attack(Character opponent)
        {
            opponent.Health -= this.AttackDamage;
            return $"{Name} attacks {opponent.Name} for {AttackDamage} damage";
        }

    }
}
