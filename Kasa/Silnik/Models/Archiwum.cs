using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    [Serializable]
    public class Archiwum
    {
        public ObservableCollection<Lot> loty;

        public Archiwum()
        {
            loty = new ObservableCollection<Lot>();
        }

        public void ArchiwizujLot(Lot lot)
        {
            loty.Add(lot);
        }
    }
}
