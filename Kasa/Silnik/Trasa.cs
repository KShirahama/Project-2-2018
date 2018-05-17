using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Trasa
    {
        private int odleglosc, czestotliwosc, czasPodruzy; // Czas podruzy mozna sprubowac kalkulowac z predkosci samolotu
        private TimeSpan godzinaWylotu;
        private Lotnisko wylot, destynacja;

        public Trasa(int odleglosc, int czestotliwosc, int czasPodruzy, TimeSpan godzinaWylotu, Lotnisko wylot, Lotnisko destynacja)
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
