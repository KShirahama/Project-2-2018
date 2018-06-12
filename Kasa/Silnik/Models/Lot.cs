using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Silnik
{
    public class Lot : PodstawowaKlasaPowiadomien
    {
        private Samolot samolot;
        private Trasa trasa;
        private TimeSpan czasPodruzy;
        private DateTime dataWylotu;
        private int id, wolneRezerwacje;
        public ObservableCollection<Bilet> bilety;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public Samolot Samolot
        {
            get { return samolot; }
            set
            {
                samolot = value;
                OnPropertyChanged("Samolot");
            }
        }

        public Trasa Trasa
        {
            get { return trasa; }
            set
            {
                trasa = value;
                OnPropertyChanged("Trasa");
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

        public DateTime DataWylotu
        {
            get { return dataWylotu; }
            set
            {
                dataWylotu = value;
                OnPropertyChanged("DataWylotu");
            }
        }

        public int WolneRezerwacje
        {
            get { return wolneRezerwacje; }
            set
            {
                wolneRezerwacje = value;
                OnPropertyChanged("WolneRezerwacje");
            }
        }

        public Lot(Samolot samolot, Trasa trasa, DateTime dataWylotu)
        {
            this.samolot = samolot;
            this.trasa = trasa;
            this.dataWylotu = new DateTime(dataWylotu.Year, dataWylotu.Month, dataWylotu.Day, trasa.GodzinaWylotu.Hour, trasa.GodzinaWylotu.Minute, trasa.GodzinaWylotu.Second);
            wolneRezerwacje = samolot.TypSamolotu.IloscMiejsc;
            bilety = new ObservableCollection<Bilet>();
        }
    }

}
