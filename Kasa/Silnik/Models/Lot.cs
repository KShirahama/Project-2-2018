using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Lot
    {
        private Samolot samolot;
        private Trasa trasa;
        private DateTime dataWylotu;
        private int wolneRezerwacje;
        private List<Bilet> bilety;

        public Lot(Samolot samolot, Trasa trasa, DateTime dataWylotu)
        {
            this.samolot = samolot;
            this.trasa = trasa;
            this.dataWylotu = dataWylotu;
            wolneRezerwacje = samolot.liczbaMiejsc;
            bilety = new List<Bilet>();
        }
    }

}
