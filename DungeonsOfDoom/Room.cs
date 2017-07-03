using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Room : WorldItem
    {
        public Monster Monster { get; set; }
        public Item Item { get; set; }

        public Room() : base('.')
        {

        }
    }
}
