using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Bilet
    {
        private Klient klient;
        private int cena;
        private int ID;

        public Bilet(Klient klient, int cena, int ID)
        {
            this.klient = klient;
            this.cena = cena;
            this.ID = ID;
        }
    }
}
