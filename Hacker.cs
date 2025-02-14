using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    internal class Hacker
    {
        public string Nev { get; private set; }
        public int KepessegSzint { get; private set; }

        public Hacker(string nev, int kepessegSzint)
        {
            Nev = nev;
            KepessegSzint = kepessegSzint;
        }

        public bool HackelesiKiserlet(Celpont celpont, Technikak technika)
        {
            int hackEro = KepessegSzint + technika.Ero;
            return hackEro > celpont.VedelemSzint;
        }
    }
}
