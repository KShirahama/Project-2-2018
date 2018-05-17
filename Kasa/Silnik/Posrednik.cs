using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik
{
    public class Posrednik : Klient
    {
        private String nazwa;

        public Posrednik(String nazwa)
        {
            this.nazwa = nazwa;
        }
    }
}
