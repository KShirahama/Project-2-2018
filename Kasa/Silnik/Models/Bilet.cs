using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Bilet : PodstawowaKlasaPowiadomien
    {
        private Klient klient;
        private int cena;
        private int id;

        public int ID
        {
            get { return ID; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }
        public Klient Klient
        {
            get { return klient; }
            set
            {
                klient = value;
                OnPropertyChanged("Klient");
            }
        }

        public Bilet(Klient klient, int cena, int ID)
        {
            this.klient = klient;
            this.cena = cena;
            this.ID = ID;
        }
    }
}
