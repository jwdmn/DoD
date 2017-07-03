using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Backpack { get; set; }
        public string Name { get; set; }

        public Player(int x, int y, string name) : base(50, 5, 'P')
        {
            X = x;
            Y = y;
            Backpack = new List<Item>();
            Name = name;
        }

    }
}
