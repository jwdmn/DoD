using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    public abstract class Item : WorldItem, IPickupAble
    {
        
        public string Name { get; }

        public Item(string name) : base('I')
        {
            Name = name;
        }

        public abstract string GetPickedUp(Player player);

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
