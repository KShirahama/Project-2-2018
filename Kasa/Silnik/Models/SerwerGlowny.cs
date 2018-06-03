using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    class SerwerGlowny
    {
        List<Lotnisko> lotniska;
        List<Klient> klienci;
        List<Trasa> trasy;
        List<Lot> loty;
        Archiwum archiwum;

        public SerwerGlowny()
        {
            lotniska = new List<Lotnisko>();
            klienci = new List<Klient>();
            trasy = new List<Trasa>();
            loty = new List<Lot>();
            archiwum = new Archiwum();
        }

        public void DodajLotnisko(Lotnisko lotnisko)
        {
            lotniska.Add(lotnisko);
        }

        public Lotnisko UsunLotnisko(Lotnisko lotnisko)
        {
            Lotnisko rLotnisko = lotniska.FirstOrDefault(x => x == lotnisko);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            lotniska.Remove(rLotnisko);
            return rLotnisko;
        }

        public void DodajKlienta(Klient klient)
        {

            klienci.Add(klient);
        }

        public Klient UsunKlienta(Klient klient)
        {
            Klient rKlient = klienci.FirstOrDefault(x => x == klient);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            klienci.Remove(rKlient);
            return rKlient;
        }

        public void DodajTrase(Trasa trasa)
        {
            trasy.Add(trasa);
        }

        public Trasa UsunTrase(Trasa trasa)
        {
            Trasa rTrasa = trasy.FirstOrDefault(x => x == trasa);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            trasy.Remove(rTrasa);
            return rTrasa;
        }

        public void DodajLoto(Lot lot)
        {
            loty.Add(lot);
        }

        public Lot UsunLot(Lot lot)
        {
            Lot rLot = loty.FirstOrDefault(x => x == lot);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            loty.Remove(rLot);
            archiwum.ArchiwizujLot(rLot);
            return rLot;
        }

    }
}
