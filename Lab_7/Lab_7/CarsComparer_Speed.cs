using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    class CarsComparer_Speed : IComparer<Cars>
    {
        public int Compare(Cars x1, Cars x2)
        {
            if (x1.Speed > x2.Speed) { return 1; }
            else if (x1.Speed < x2.Speed) { return -1; }
            else { return 0; }
        }
    }
}
