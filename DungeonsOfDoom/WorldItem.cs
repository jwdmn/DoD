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

        public WorldItem(char symbol)
        {
            Symbol = symbol;
        }

    }
}
