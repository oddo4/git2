using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedicnostTest
{
    class Krajta : Studenokrevny
    {
        public Krajta(string jmeno, string vyskyt, int teplota, bool zije = true)
        {
            this.Jmeno = jmeno;
            this.Zije = zije;
            this.Vyskyt = vyskyt;
            this.Teplota = teplota;
        }
    }
}
