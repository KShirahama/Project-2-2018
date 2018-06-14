using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    /// <summary>
    /// Main Klient class
    /// Represents base of clients representation.
    /// </summary>
    [Serializable]
    public class Klient :PodstawowaKlasaPowiadomien
    {
        /// <summary>
        /// Stores ID
        /// </summary>
        private int id;

        /// <summary>
        /// Gets and sets ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
    }
}
