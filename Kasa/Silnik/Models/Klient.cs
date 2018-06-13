using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    [Serializable]
    public class Klient :PodstawowaKlasaPowiadomien
    {
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
    }
}
