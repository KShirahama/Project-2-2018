using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    /// <summary>
    /// Klient class
    /// Represents individual clients.
    /// </summary>
    [Serializable]
    public class KlientIndywidualny : Klient
    {
        /// <summary>
        /// Stores Imie and Nazwisko
        /// </summary>
        private String imie, nazwisko;

        /// <summary>
        /// Gets and sets Imie
        /// </summary>
        public String Imie
        {
            get { return imie; }
            set
            {
                imie = value;
                OnPropertyChanged("Imie");
            }
        }
        /// <summary>
        /// Gets and sets Nazwisko
        /// </summary>
        public String Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;
                OnPropertyChanged("Nazwisko");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlientIndywidualny"/> class.
        /// </summary>
        /// <param name="imie">Name of person</param>
        /// <param name="nazwisko">Surname of person</param>
        public KlientIndywidualny(String imie, String nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
