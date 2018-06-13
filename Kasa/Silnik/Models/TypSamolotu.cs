using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Silnik.Models
{
    [Serializable]
    public class TypSamolotu : PodstawowaKlasaPowiadomien
    {
        private int id, zasieg, iloscMiejsc;
        private String nazwa;

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

        public int Zasieg
        {
            get { return zasieg; }
            set
            {
                zasieg = value;
                OnPropertyChanged("Zasieg");
            }
        }
        public int IloscMiejsc
        {
            get { return iloscMiejsc; }
            set
            {
                iloscMiejsc = value;
                OnPropertyChanged("IloscMiejsc");
            }
        }

        public TypSamolotu(int id, String nazwa, int zasieg, int iloscMiejsc)
        {
            this.id = id;
            this.nazwa = nazwa;
            this.zasieg = zasieg;
            this.iloscMiejsc = iloscMiejsc;
        }
        public TypSamolotu(TypSamolotu typ)
        {
            id = typ.id;
            nazwa = typ.nazwa;
            zasieg = typ.zasieg;
            iloscMiejsc = typ.iloscMiejsc;
        }
    }
}
