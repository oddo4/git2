using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedicnostTest
{
    class Zvire
    {
        public string Jmeno { get; set; }
        public bool Zije { get; set; }
        public string Vyskyt { get; set; }

        public void Jez()
        {
            if (Zije)
            {
                Console.WriteLine(Jmeno + " jí.");
            }
            else
            {
                JeNazivu();
            }
        }

        public void Pij()
        {
            if (Zije)
            {
                Console.WriteLine(Jmeno + " pije.");
            }
            else
            {
                JeNazivu();
            }
        }

        public void JeNazivu()
        {
            if (Zije)
            {
                Console.WriteLine(Jmeno + " žije.");
            }
            else
            {
                Console.WriteLine(Jmeno + " nežije.");
            }
        }
    }
}
