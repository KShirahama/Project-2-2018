using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Silnik
{
    /// <summary>
    /// Base Lotnisko class
    /// Represents airport.
    /// </summary>
    [Serializable]
    public class Lotnisko : PodstawowaKlasaPowiadomien
    {
        /// <summary>
        /// Stores ID
        /// </summary>
        private int id;
        /// <summary>
        /// Stores Nazwa
        /// </summary>
        private String nazwa;

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
        /// <summary>
        /// Gets and sets Nazwa
        /// </summary>
        public String Nazwa
        {
            get { return nazwa; }
            private set
            {
                nazwa = value;
                OnPropertyChanged("Nazwa");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lotnisko"/> class.
        /// </summary>
        /// <param name="id">Identificator of the airport</param>
        /// <param name="nazwa">Name of the airport</param>
        public Lotnisko(int id, String nazwa)
        {
            this.id = id;
            this.nazwa = nazwa;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lotnisko"/> class by copying paramethers of another.
        /// </summary>
        /// <param name="lotnisko">Airport to be copied.</param>
        public Lotnisko(Lotnisko lotnisko)
        {
            id = lotnisko.id;
            nazwa = lotnisko.nazwa;
        }
    }
}
