using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    public class Player : Character, IAbleToPickup
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<IPickupAble> Backpack { get; set; }

        public Player(int x, int y, string name) : base(50, 5, 'P', name)
        {
            X = x;
            Y = y;
            Backpack = new List<IPickupAble>();
        }

        //public override string Attack(Character opponent)
        //{
        //    opponent.Health -= this.AttackDamage;
        //    return $"{Name} attacks {opponent.Name} for {AttackDamage} damage";
        //}

    }
}
