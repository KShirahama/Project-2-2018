using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    class Archiwum
    {
        List<Lot> loty;

        public Archiwum()
        {
            loty = new List<Lot>();
        }

        public void ArchiwizujLot(Lot lot)
        {
            loty.Add(lot);
        }
    }
}
