using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    [Serializable]
    public class KlientIndywidualny : Klient
    {
        private String imie, nazwisko;

        public String Imie
        {
            get { return imie; }
            set
            {
                imie = value;
                OnPropertyChanged("Imie");
            }
        }
        public String Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;
                OnPropertyChanged("Nazwisko");
            }
        }

        public KlientIndywidualny(String imie, String nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
