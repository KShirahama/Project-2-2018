using Silnik.Models;
using Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Silnik
{
    public class SerwerGlowny : PodstawowaKlasaPowiadomien
    {
        public ObservableCollection<Lotnisko> lotniska;
        public ObservableCollection<TypSamolotu> typySamolotow;
        public ObservableCollection<Samolot> samoloty;
        public ObservableCollection<Klient> klienci;
        public ObservableCollection<Trasa> trasy;
        public ObservableCollection<Lot> loty;
        public Archiwum archiwum;
        public int lotniskaID, typySamolotowID, samolotyID, klienciID, trasyID, lotyID;
        

        public SerwerGlowny()
        {
            lotniska = new ObservableCollection<Lotnisko>();
            typySamolotow = new ObservableCollection<TypSamolotu>();
            samoloty = new ObservableCollection<Samolot>();
            klienci = new ObservableCollection<Klient>();
            trasy = new ObservableCollection<Trasa>();
            loty = new ObservableCollection<Lot>();
            archiwum = new Archiwum();
            lotniskaID = 0;
            typySamolotowID = 0;
            samolotyID = 0;
            klienciID = 0;
            trasyID = 0;
            lotyID = 0;
        }

        public void DodajLotnisko(Lotnisko lotnisko)
        {
            lotnisko.ID = lotniskaID;
            lotniska.Add(new Lotnisko(lotnisko));
            lotniskaID++;
        }

        public Lotnisko UsunLotnisko(Lotnisko lotnisko)
        {
            Lotnisko rLotnisko = lotniska.FirstOrDefault(x => x == lotnisko);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            lotniska.Remove(rLotnisko);
            return rLotnisko;
        }


        public void DodajSamolot(Samolot samolot)
        {
            samolot.ID = samolotyID;
            samoloty.Add(new Samolot(samolot));
            samolotyID++;
        }

        public Samolot UsunSamolot(Samolot samolot)
        {
            Samolot rSamolot = samoloty.FirstOrDefault(x => x == samolot);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            samoloty.Remove(rSamolot);
            return rSamolot;
        }

        public void DodajTypSamolotu(TypSamolotu typ)
        {
            typ.ID = typySamolotowID;
            typySamolotow.Add(new TypSamolotu(typ));
            typySamolotowID++;
        }

        public TypSamolotu UsunTypSamolotu(TypSamolotu typ)
        {
            TypSamolotu rTyp = typySamolotow.FirstOrDefault(x => x == typ);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            typySamolotow.Remove(rTyp);
            return rTyp;
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

        public void DodajLot(Lot lot)
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
