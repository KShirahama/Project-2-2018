using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    /// <summary>
    /// Posrednik class
    /// Represents middleman.
    /// </summary>
    [Serializable]
    public class Posrednik : Klient
    {
        /// <summary>
        /// Stores Nazwa
        /// </summary>
        private String nazwa;

        /// <summary>
        /// Gets and sets Nazwa
        /// </summary>
        public String Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
                OnPropertyChanged("Nazwa");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Posrednik"/> class.
        /// </summary>
        /// <param name="nazwa">Name of middleman</param>
        public Posrednik(String nazwa)
        {
            this.nazwa = nazwa;
        }
    }
}
