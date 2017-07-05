using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
    {
        static Random random = new Random();

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
