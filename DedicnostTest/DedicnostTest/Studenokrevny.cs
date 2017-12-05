using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedicnostTest
{
    class Studenokrevny : Zvire
    {
        public int Teplota { get; set; }

        public void VyhrejSe()
        {
            if (Zije)
            {
                Console.WriteLine(Jmeno + " se vyhřívá.");
            }
            else
            {
                JeNazivu();
            }
        }
    }
}
