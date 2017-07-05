using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class WorldItem
    {
        public char Symbol { get; }
        public static int MonsterCount { get; set; }

        public WorldItem(char symbol)
        {
            Symbol = symbol;
        }

    }
}
