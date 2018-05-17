using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Samolot
    {
        private String nazwa;
        private int ID, zasieg, liczbaMiejsc;

        public Samolot(String nazwa, int ID, int zasieg, int liczbaMiejsc)
        {
            this.nazwa = nazwa;
            this.ID = ID;
            this.zasieg = zasieg;
            this.liczbaMiejsc = liczbaMiejsc;
        }
    }
}
