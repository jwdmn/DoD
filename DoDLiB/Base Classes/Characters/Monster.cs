using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    /// <summary>
    /// Represents a Monster in the game
    /// A Monster has Health, AttackDamage, Name and a Symbol
    /// </summary>
    public class Monster : Character, IPickupAble
    {
        /// <summary>
        /// Represents a Monster in the game
        /// </summary>
        /// <param name="health">the characters health points</param>
        /// <param name="attackDamage">the characters attack damage</param>
        /// <param name="name">the characters name</param>
        public Monster(int health, int attackDamage, string name) :base(health, attackDamage, 'M', name)
        {
            MonsterCount++;
        }

        public string ItemGetPickedUp(Player player)
        {
            player.Backpack.Add(this);
            return $"{this.Name} was added to backpack";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
