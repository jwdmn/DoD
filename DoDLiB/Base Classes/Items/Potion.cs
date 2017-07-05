using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    public class Potion : Item
    {
        public int Healing { get; set; }

        public Potion(string name, int healing) :base(name)
        {
            Healing = healing;
        }

        public override string GetPickedUp(Player player)
        {
            player.Health += this.Healing;
            return $"{player.Name} picked up {this.Name}. Health increased by {this.Healing}.";
        }
    }
}
