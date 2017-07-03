using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : WorldItem
    {
        //glöm inte mickes fannybag
        public string Name { get; set; }

        public Item(string name) : base('I')
        {
            Name = name;
        }
    }
}
