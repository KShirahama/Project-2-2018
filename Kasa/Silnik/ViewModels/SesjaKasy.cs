using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.ViewModels
{
    public class SesjaKasy : INotifyPropertyChanged
    {
        private SerwerGlowny _serwer;
        public event PropertyChangedEventHandler PropertyChanged = null;
        private Lotnisko _aktualneLotnisko = new Lotnisko(null);
        private String _nazwaLotniska = null;
        public SerwerGlowny Serwer
        {
            get { return _serwer; }
            private set
            {
                _serwer = value;
            }
        }
        public Lotnisko AktualneLotnisko
        {
            get
            {
                return _aktualneLotnisko;
            }
            set
            {
                _aktualneLotnisko = value;
                OnPropertyChanged("AktualneLotnisko");
                OnPropertyChanged("NazwaLotniska");
            }
        }
        public String NazwaLotniska
        {
            get
            {
                return _nazwaLotniska;
            }
            set
            {
                _nazwaLotniska = null;
                OnPropertyChanged("NazwaLotniska");
            }
        }

        public SesjaKasy()
        {
            Serwer = new SerwerGlowny();

        }

        public void DodajSamolot()
        {
            Serwer.DodajLotnisko(_aktualneLotnisko);
        }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
