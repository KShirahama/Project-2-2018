using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    [Serializable]
    public class Trasa : PodstawowaKlasaPowiadomien
    {
        private int id, odleglosc, czestotliwosc;
        private DateTime godzinaWylotu;
        private Lotnisko wylot, destynacja;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
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

        public Trasa(int id, int odleglosc, int czestotliwosc, DateTime godzinaWylotu, Lotnisko wylot, Lotnisko destynacja)
        {
            this.odleglosc = odleglosc;
            this.czestotliwosc = czestotliwosc;
            this.godzinaWylotu = godzinaWylotu;
            this.wylot = wylot;
            this.destynacja = destynacja;
        }
        public Trasa(Trasa trasa)
        {
            this.odleglosc = trasa.odleglosc;
            this.czestotliwosc = trasa.czestotliwosc;
            this.godzinaWylotu = trasa.godzinaWylotu;
            this.wylot = trasa.wylot;
            this.destynacja = trasa.destynacja;
        }
    }
}
