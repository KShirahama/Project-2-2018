using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    /// <summary>
    /// The main Bilet class.
    /// Represents ticket and it values.
    /// </summary>
    [Serializable]
    public class Bilet : PodstawowaKlasaPowiadomien
    {
        /// <summary>
        /// Stores Klient
        /// </summary>
        private Klient klient;
        /// <summary>
        /// Stores Cena
        /// </summary>
        private int cena;
        /// <summary>
        /// Stores ID
        /// </summary>
        private int id;

        /// <summary>
        /// Gets and sets id
        /// </summary>
        public int ID
        {
            get { return ID; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        /// <summary>
        /// Gets and sets Cena
        /// </summary>
        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }
        /// <summary>
        /// Gets and sets Klient
        /// </summary>
        public Klient Klient
        {
            get { return klient; }
            set
            {
                klient = value;
                OnPropertyChanged("Klient");
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Bilet"/> class.</summary>
        public Bilet(Klient klient, int cena, int ID)
        {
            this.klient = klient;
            this.cena = cena;
            this.ID = ID;
        }
    }
}
