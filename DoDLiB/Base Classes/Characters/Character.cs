using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    /// <summary>
    /// Represents a character in the game. 
    /// A character has Health, AttackDamage and a Name
    /// </summary>
    public abstract class Character : WorldItem
    {
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Represents a character in the game
        /// </summary>
        /// <param name="health">the characters health points</param>
        /// <param name="attackDamage">the characters attack damage</param>
        /// <param name="symbol">the characters symbol shown on the world map</param>
        /// <param name="name">the characters name</param>
        public Character(int health, int attackDamage, char symbol, string name) : base(symbol)
        {
            Health = health;
            AttackDamage = attackDamage;
            Name = name;
        }

        /// <summary>
        /// Default method on what happends when this character fights another character
        /// </summary>
        /// <param name="opponent">The character that this character is fighting</param>
        /// <returns></returns>
        public virtual string Attack(Character opponent)
        {
            opponent.Health -= this.AttackDamage;
            return $"{Name} attacks {opponent.Name} for {AttackDamage} damage";
        }

    }
}
