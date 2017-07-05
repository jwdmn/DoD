using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public int AddDamage { get; set; }

        public Weapon(int addDamage, string name) : base(name)
        {
            AddDamage = addDamage;
        }

        public override string GetPickedUp(Player player)
        {
            player.AttackDamage += this.AddDamage;
            return $"{player.Name} picked up {this.Name}. Attack power increased by {this.AddDamage}.";
        }
    }
}
