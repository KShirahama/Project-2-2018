using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    /// <summary>
    /// The main Archiwum class.
    /// </summary>
    [Serializable]
    public class Archiwum
    {
        /// <summary>
        /// Stores old flights.
        /// </summary>
        public ObservableCollection<Lot> loty;

        /// <summary>
        /// Constructor of archiwum.
        /// </summary>
        public Archiwum()
        {
            loty = new ObservableCollection<Lot>();
        }

        /// <summary>
        /// Adds lot to Archiwum.
        /// </summary>
        ///<param name="lot"> Lot to be stored.</param>
        public void ArchiwizujLot(Lot lot)
        {
            loty.Add(new Lot(lot));
        }
    }
}
