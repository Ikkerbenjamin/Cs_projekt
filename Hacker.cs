using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Hacker
    {
        public string Nev { get; private set; }
        public int KepessegSzint { get; private set; }
        public int Energia { get; set; }

        public Hacker(string nev, int kepessegSzint, int energia)
        {
            Nev = nev;
            KepessegSzint = kepessegSzint;
            Energia = energia;
        }
    }


}
