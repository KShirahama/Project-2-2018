﻿using Silnik.Models;
using Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Silnik
{
   [Serializable]
    public class SerwerGlowny : PodstawowaKlasaPowiadomien
    {
        public ObservableCollection<Lotnisko> lotniska;
        public ObservableCollection<TypSamolotu> typySamolotow;
        public ObservableCollection<Samolot> samoloty;
        public ObservableCollection<Klient> klienci;
        public ObservableCollection<Trasa> trasy;
        public ObservableCollection<Lot> loty;
        public Archiwum archiwum;
        public int lotniskaID, typySamolotowID, samolotyID, klienciID, trasyID, lotyID, rezerwacjeID;
        

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

            GenerujLoty();
        }

        public void DodajLotnisko(Lotnisko lotnisko)
        {
            lotnisko.ID = lotniskaID;
            lotniska.Add(new Lotnisko(lotnisko));
            lotniskaID++;
            GenerujLoty();
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
            GenerujLoty();
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
            klient.ID = klienciID;
            klienci.Add(klient);
            klienciID++;
        }

        public Klient UsunKlienta(Klient klient)
        {
            Klient rKlient = klienci.FirstOrDefault(x => x == klient);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            UsunBilety(rKlient);
            klienci.Remove(rKlient);
            return rKlient;
        }

        public void UsunBilety(Klient klient)
        {
            foreach(Lot lot in loty.Select(x => x.bilety.Where(y => y.Klient == klient)))
            {
                foreach (Bilet bilet in lot.bilety.Where(x => x.Klient == klient).ToList())
                {
                    lot.UsunBilet(bilet);
                }
            }
        }

        public void DodajTrase(Trasa trasa)
        {
            trasa.ID = trasyID;
            trasy.Add(new Trasa(trasa));
            trasyID++;
            GenerujLoty();
        }

        public Trasa UsunTrase(Trasa trasa)
        {
            Trasa rTrasa = trasy.FirstOrDefault(x => x == trasa);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            trasy.Remove(rTrasa);
            return rTrasa;
        }

        public void DodajLot(Lot lot)
        {
            lot.ID = lotyID;
            var uiContext = SynchronizationContext.Current;
            loty.Add(new Lot(lot));
            lotyID++;
        }

        public Lot UsunLot(Lot lot)
        {
            Lot rLot = loty.FirstOrDefault(x => x == lot);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            samoloty.First(x => x == rLot.Samolot).ZmienLotnisko(lotniska.FirstOrDefault(x => x.ID == rLot.Trasa.Destynacja.ID));
            loty.Remove(rLot);
            archiwum.ArchiwizujLot(rLot);
            return rLot;
        }

        public void GenerujLoty()
        {
            DateTime data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            foreach (Lot lot in loty)
            {
                if (lot.DataWylotu < data) lot.WTrakcie = true;
                if ((lot.DataWylotu + lot.CzasPodruzy) < data)
                {
                    archiwum.ArchiwizujLot(lot);
                    samoloty.FirstOrDefault(x => x == lot.Samolot).ZmienLotnisko(lot.Trasa.Destynacja);
                    UsunLot(lot);
                }
            }
            for (int i = 0; i < 30; ++i)
            {
                DateTime dataPlus = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                foreach (Trasa trasa in trasy)
                {
                    if (i % trasa.Czestotliwosc != 0) break;
                    if (samoloty.Where(x => x.AktualneLotnisko == trasa.Wylot && x.Przydzielony == false && x.TypSamolotu.Zasieg >= trasa.Odleglosc).Count() != 0)
                    {
                        dataPlus = dataPlus.AddDays(i);
                        if (loty.Where(x => x.Trasa == trasa && x.DataWylotu.Day == dataPlus.Day && x.DataWylotu.Month == dataPlus.Month && x.DataWylotu.Year == dataPlus.Year).Count() == 0)
                        {
                            DodajLot(new Lot(samoloty.FirstOrDefault(x => x.AktualneLotnisko == trasa.Wylot && x.Przydzielony == false && x.TypSamolotu.Zasieg >= trasa.Odleglosc), trasa, dataPlus));
                            samoloty.FirstOrDefault(x => x.AktualneLotnisko == trasa.Wylot).Przydzielony = true;
                        }
                    }
                }
            }
        }
    }
}
