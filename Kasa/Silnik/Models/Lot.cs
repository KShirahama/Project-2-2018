using System;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Silnik
{
    /// <summary>
    /// Base Lot class
    /// Represents flight.
    /// </summary>
    [Serializable]
    public class Lot : PodstawowaKlasaPowiadomien
    {
        /// <summary>Stores Samolot</summary>
        private Samolot samolot;
        /// <summary>Stores Trasa</summary>
        private Trasa trasa;
        /// <summary>Stores CzasPodruzy</summary>
        private TimeSpan czasPodruzy;
        /// <summary>Stores DataWylotu</summary>
        private DateTime dataWylotu;
        /// <summary>Stores ID and WolneRezerwacje</summary>
        private int id, wolneRezerwacje;
        /// <summary>Stores Bilety</summary>
        public ObservableCollection<Bilet> bilety;
        /// <summary>Stores WTrakcie</summary>
        private bool wTrakcie;

        /// <summary>
        /// Gets and sets ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        /// <summary>
        /// Gets and sets Samolot
        /// </summary>
        public Samolot Samolot
        {
            get { return samolot; }
            set
            {
                samolot = value;
                OnPropertyChanged("Samolot");
            }
        }
        /// <summary>
        /// Gets and sets Trasa
        /// </summary>
        public Trasa Trasa
        {
            get { return trasa; }
            set
            {
                trasa = value;
                OnPropertyChanged("Trasa");
            }
        }

        /// <summary>
        /// Gets and sets CzasPodruzy
        /// </summary>
        public TimeSpan CzasPodruzy
        {
            get { return czasPodruzy; }
            set
            {
                czasPodruzy = value;
                OnPropertyChanged("CzasPodruzy");
            }
        }

        /// <summary>
        /// Gets and sets DataWylotu
        /// </summary>
        public DateTime DataWylotu
        {
            get { return dataWylotu; }
            set
            {
                dataWylotu = value;
                OnPropertyChanged("DataWylotu");
            }
        }

        /// <summary>
        /// Gets and sets WolneRezerwacje
        /// </summary>
        public int WolneRezerwacje
        {
            get { return wolneRezerwacje; }
            set
            {
                wolneRezerwacje = value;
                OnPropertyChanged("WolneRezerwacje");
            }
        }

        /// <summary>
        /// Gets and sets WTrakcie
        /// </summary>
        public bool WTrakcie
        {
            get { return wTrakcie; }
            set
            {
                wTrakcie = value;
                OnPropertyChanged("WTrakcie");
            }
        }

        /// <summary>
        /// Gets automatic paramether DataPrzylotu
        /// </summary>
        public DateTime DataPrzylotu
        {
            get { return dataWylotu.Add(czasPodruzy); }
        }

        /// <summary>
        /// Gets automatic paramether Rezerwacje
        /// </summary>
        public int Rezerwacje
        {
            get { return bilety.Count(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lot"/> class.
        /// </summary>
        /// <param name="dataWylotu">Departure date.</param>
        /// <param name="samolot">Plane to be used.</param>
        /// <param name="trasa">Flight route to be taken.</param>
        public Lot(Samolot samolot, Trasa trasa, DateTime dataWylotu)
        {
            this.samolot = samolot;
            this.trasa = trasa;
            this.dataWylotu = new DateTime(dataWylotu.Year, dataWylotu.Month, dataWylotu.Day, trasa.GodzinaWylotu.Hour, trasa.GodzinaWylotu.Minute, trasa.GodzinaWylotu.Second);
            wolneRezerwacje = samolot.TypSamolotu.IloscMiejsc;
            bilety = new ObservableCollection<Bilet>();
            czasPodruzy = new TimeSpan(((int)Trasa.Odleglosc / 1000) % 24, (((int)Trasa.Odleglosc / 10) - ((int)Trasa.Odleglosc / 1000)) % 60, 0);
            wTrakcie = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lot"/> class by coping paramethers of other.
        /// </summary>
        /// <param name="lot">Flight to be copied</param>
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

        /// <summary>
        /// Adds Bilet to class.
        /// </summary>
        /// <param name="bilet">Ticket to be added.</param>
        /// <returns> <c>true</c> if bilet could be added; otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Removes Bilet from class.
        /// </summary>
        /// <param name="bilet">Ticket to remove.</param>
        public void UsunBilet(Bilet bilet)
        {
            bilety.Remove(bilety.FirstOrDefault(x => x == bilet));
            wolneRezerwacje++;
        }

    }
}
