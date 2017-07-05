using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Utils class for randomizing
    /// </summary>
    public static class RandomUtils
    {
        static Random random = new Random();

        /// <summary>
        /// Rolls for specified winchance
        /// </summary>
        /// <param name="winPercentage">percent win chance</param>
        /// <returns></returns>
        public static bool RandomRoll(int winPercentage)
        {
            int result = random.Next(1, 101);

            if (result <= winPercentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
