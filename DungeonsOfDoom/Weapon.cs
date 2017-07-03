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
    }
}
