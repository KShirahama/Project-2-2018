using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Silnik
{
    public class Lotnisko : PodstawowaKlasaPowiadomien
    {
        private int id;
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

        public Lotnisko(int id, String nazwa)
        {
            this.id = id;
            this.nazwa = nazwa;
        }

        public Lotnisko(Lotnisko lotnisko)
        {
            id = lotnisko.id;
            nazwa = lotnisko.nazwa;
        }
    }
}
