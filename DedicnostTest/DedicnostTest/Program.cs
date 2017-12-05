using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedicnostTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Lev lev = new Lev("Lev", "Afrika");
            Krajta krajta = new Krajta("Krajta", "Jižní Amerika", 10, false);
            //krajta.Zije = false;

            lev.JeNazivu();
            lev.Jez();
            lev.Pij();

            krajta.JeNazivu();
            krajta.Jez();
            krajta.Pij();
            krajta.VyhrejSe();
        }
    }
}
