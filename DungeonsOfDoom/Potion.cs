using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Potion : Item
    {
        public int Healing { get; set; }

        public Potion(string name, int healing) :base(name)
        {
            Healing = healing;
        }
    }
}
