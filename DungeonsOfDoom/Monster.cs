using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Monster : Character, IPickupAble
    {

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
