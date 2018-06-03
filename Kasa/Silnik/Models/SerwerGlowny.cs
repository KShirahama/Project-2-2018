using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class SerwerGlowny
    {
        List<Lotnisko> lotniska;
        List<Klient> klienci;
        List<Trasa> trasy;
        List<Lot> loty;
        private int liczbaKlientow;
        Archiwum archiwum;

        public SerwerGlowny()
        {
            lotniska = new List<Lotnisko>();
            klienci = new List<Klient>();
            trasy = new List<Trasa>();
            loty = new List<Lot>();
            liczbaKlientow = 0;
            archiwum = new Archiwum();
        }

        public void DodajLotnisko(Lotnisko lotnisko)
        {
            lotniska.Add(lotnisko);
        }

        public void UsunLotnisko(Lotnisko lotnisko)
        {
            lotniska.Remove(lotnisko);
        }

    }
}
