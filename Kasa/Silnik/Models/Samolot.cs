using Silnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Silnik
{
    public class Samolot : PodstawowaKlasaPowiadomien
    {
        private String nazwa;
        private int id;
        private TypSamolotu typSamolotu;
        private Lotnisko aktualneLotnisko;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public String Nazwa
        {
            get { return nazwa; }
            private set
            {
                nazwa = value;
                OnPropertyChanged("Nazwa");
            }
        }

        public TypSamolotu TypSamolotu
        {
            get { return typSamolotu; }
            private set
            {
                typSamolotu = value;
                OnPropertyChanged("TypSamolotu");
            }
        }

        public Lotnisko AktualneLotnisko
        {
            get { return aktualneLotnisko; }
            private set
            {
                aktualneLotnisko = value;
                OnPropertyChanged("AktualneLotnisko");
            }
        }

        public Samolot(String nazwa, int id, TypSamolotu typ, Lotnisko lotnisko)
        {
            this.nazwa = nazwa;
            this.id = id;
            typSamolotu = typ;
            aktualneLotnisko = lotnisko;
        }

        public Samolot(Samolot samolot)
        {
            this.nazwa = samolot.nazwa;
            this.id = samolot.id;
            typSamolotu = samolot.typSamolotu;
            aktualneLotnisko = samolot.aktualneLotnisko;
        }

        public void ZmienLotnisko(Lotnisko lotnisko)
        {
            aktualneLotnisko = lotnisko;
        }
    }
}
