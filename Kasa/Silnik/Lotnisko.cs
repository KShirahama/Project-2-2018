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

        public Lotnisko(String nazwa)
        {
            this.nazwa = nazwa;
            samoloty = new List<Samolot>();
        }
    }
}
