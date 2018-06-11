using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Trasa : PodstawowaKlasaPowiadomien
    {
        private int odleglosc, czestotliwosc; // Czas podruzy mozna sprubowac kalkulowac z predkosci samolotu
        private TimeSpan czasPodruzy;
        private DateTime godzinaWylotu;
        private Lotnisko wylot, destynacja;

        public Lotnisko Wylot
        {
            get { return wylot; }
            set
            {
                wylot = value;
                OnPropertyChanged("Wylot");
            }
        }
        public Lotnisko Destynacja
        {
            get { return destynacja; }
            set
            {
                destynacja = value;
                OnPropertyChanged("Sestynacja");
            }
        }
        public DateTime GodzinaWylotu
        {
            get { return godzinaWylotu; }
            set
            {
                godzinaWylotu = value;
                OnPropertyChanged("GodzinaWylotu");
            }
        }
        public TimeSpan CzasPodruzy
        {
            get { return czasPodruzy; }
            set
            {
                czasPodruzy = value;
                OnPropertyChanged("CzasPodruzy");
            }
        }
        public int Odleglosc
        {
            get { return odleglosc; }
            set
            {
                odleglosc = value;
                OnPropertyChanged("Odleglosc");
            }
        }
        public int Czestotliwosc
        {
            get { return czestotliwosc; }
            set
            {
                czestotliwosc = value;
                OnPropertyChanged("Czestotliwosc");
            }
        }

        public Trasa(int odleglosc, int czestotliwosc, TimeSpan czasPodruzy, DateTime godzinaWylotu, Lotnisko wylot, Lotnisko destynacja)
        {
            this.odleglosc = odleglosc;
            this.czestotliwosc = czestotliwosc;
            this.czasPodruzy = czasPodruzy;
            this.godzinaWylotu = godzinaWylotu;
            this.wylot = wylot;
            this.destynacja = destynacja;
        }
    }
}
