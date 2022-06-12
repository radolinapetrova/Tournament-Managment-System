using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Badminton : SportType
    {
        public override string ToString()
        {
            return "badminton";
        }

        public override void CheckResult(int result1, int result2)
        {
            if ((result1 < 21 && result2 < 21) || result1 > 30 || result2 > 30 || ((result1 > 20 && result2 > 20) && (result2 < 29 && result1 < 29) && Math.Max(result1, result2) - Math.Min(result1, result2) != 2) || result2 == result1 || result1 < 0 || result2 < 0 || (result1 < 20 && result2 > 21) || (result1 > 21 && result2 < 20))
            {
                throw new Exception("The results you entered are invalid");
            }
        }
    }
}
