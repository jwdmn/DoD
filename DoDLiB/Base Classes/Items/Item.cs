using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    /// <summary>
    /// Represents an Item in the game 
    /// Item has a name and a symbol
    /// </summary>
    public abstract class Item : WorldItem, IPickupAble
    {
        public string Name { get; }

        public Item(string name) : base('I')
        {
            Name = name;
        }

        public abstract string GetPickedUp(Player player);

        /// <summary>
        /// Adds items to the backpack when player detect them
        /// </summary>
        /// <param name="player">The character that picks up the item</param>
        /// <returns></returns>
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
