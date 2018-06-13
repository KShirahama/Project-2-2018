using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Silnik
{
    [Serializable]
    public class Lot : PodstawowaKlasaPowiadomien
    {
        private Samolot samolot;
        private Trasa trasa;
        private TimeSpan czasPodruzy;
        private DateTime dataWylotu;
        private int id, wolneRezerwacje;
        public ObservableCollection<Bilet> bilety;
        private bool wTrakcie;

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

        public bool WTrakcie
        {
            get { return wTrakcie; }
            set
            {
                wTrakcie = value;
                OnPropertyChanged("WTrakcie");
            }
        }

        public Lot(Samolot samolot, Trasa trasa, DateTime dataWylotu)
        {
            this.samolot = samolot;
            this.trasa = trasa;
            this.dataWylotu = new DateTime(dataWylotu.Year, dataWylotu.Month, dataWylotu.Day, trasa.GodzinaWylotu.Hour, trasa.GodzinaWylotu.Minute, trasa.GodzinaWylotu.Second);
            wolneRezerwacje = samolot.TypSamolotu.IloscMiejsc;
            bilety = new ObservableCollection<Bilet>();
            wTrakcie = false;
        }

        public Lot(Lot lot)
        {
            id = lot.id;
            samolot = lot.samolot;
            trasa = lot.trasa;
            dataWylotu = lot.dataWylotu;
            czasPodruzy = lot.czasPodruzy;
            wolneRezerwacje = lot.wolneRezerwacje;
            bilety = lot.bilety;
            wTrakcie = lot.wTrakcie;
        }

        public Boolean RezerwujBilet(Bilet bilet)
        {
            if (wolneRezerwacje <= 0)
            {
                wolneRezerwacje = 0;
                return false;
            }
            bilety.Add(bilet);
            wolneRezerwacje--;
            return true;
        }

        public void UsunBilet(Bilet bilet)
        {
            bilety.Remove(bilety.FirstOrDefault(x => x == bilet));
            wolneRezerwacje++;
        }
    }
}
