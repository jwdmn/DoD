using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    /// <summary>
    /// Represents a Ogre, that is a Monster in the game
    /// An Ogre has Health, AttackDamage and a Name
    /// </summary>
    public class Ogre : Monster
    {
        public Ogre() : base(20, 3, "Ogre")
        {

        }
    }
}
