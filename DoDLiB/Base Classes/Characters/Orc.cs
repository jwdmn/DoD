using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    public class Orc : Monster
    {
        public Orc() : base(10, 3, "Orc")
        {

        }

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
