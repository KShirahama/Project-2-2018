using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class KlientIndywidualny : Klient
    {
        private String imie, nazwisko;

        public KlientIndywidualny(String imie, String nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
