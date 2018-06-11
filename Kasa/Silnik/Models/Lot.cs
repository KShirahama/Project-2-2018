using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Lot : PodstawowaKlasaPowiadomien
    {
        private Samolot samolot;
        private Trasa trasa;
        private TimeSpan czasPodruzy;
        private DateTime dataWylotu;
        private int wolneRezerwacje;
        private List<Bilet> bilety;

        public TimeSpan CzasPodruzy
        {
            get { return czasPodruzy; }
            set
            {
                czasPodruzy = value;
                OnPropertyChanged("CzasPodruzy");
            }
        }

        public Lot(Samolot samolot, Trasa trasa, DateTime dataWylotu)
        {
            this.samolot = samolot;
            this.trasa = trasa;
            this.dataWylotu = new DateTime(dataWylotu.Year, dataWylotu.Month, dataWylotu.Day, trasa.GodzinaWylotu.Hour, trasa.GodzinaWylotu.Minute, trasa.GodzinaWylotu.Second);
            wolneRezerwacje = samolot.TypSamolotu.IloscMiejsc;
            bilety = new List<Bilet>();
        }
    }

}
