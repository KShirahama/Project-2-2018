using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Lotnisko
    {
        private String nazwa;
        private List<Samolot> samoloty;

        public String Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
            }
        } 

        public Lotnisko(String nazwa)
        {
            this.nazwa = nazwa;
            samoloty = new List<Samolot>();
        }

        public void DodajSamolot(Samolot samolot)
        {
            samoloty.Add(samolot);
        }

        public Samolot UsunSamolot(Samolot samolot)
        {
            Samolot rSamolot = samoloty.FirstOrDefault(x => x == samolot);  // Moze bedzie trzeba uzyc First zamiast FirstOrDefault
            samoloty.Remove(rSamolot);
            return rSamolot;
        }
    }
}
