using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedicnostTest
{
    class Lev : Zvire
    {
        public Lev(string jmeno, string vyskyt)
        {
            this.Jmeno = jmeno;
            this.Zije = true;
            this.Vyskyt = vyskyt;
        }
    }
}
