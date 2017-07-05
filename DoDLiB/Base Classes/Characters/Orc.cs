using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    /// <summary>
    /// Represents an Orc, that is a Monster in the game
    /// An Orch has Health, AttackDamage and a Name
    /// </summary>
    public class Orc : Monster
    {
        public Orc() : base(10, 3, "Orc")
        {

        }
        /// <summary>
        /// Represents an Orc, that is a Monster in the game
        /// </summary>
        /// <param name="opponent">Is the opponent which Orc is fighting</param>
        /// <returns></returns>
        public override string Attack(Character opponent)
        {
            if (opponent.AttackDamage > (this.AttackDamage * 2))
            {
                this.Health = 0;
                return "The orc died of fear";
            }
            else
            {
                opponent.Health -= this.AttackDamage;
                return $"{Name} attacks {opponent.Name} for {AttackDamage} damage";
            }
        }
    }
}
