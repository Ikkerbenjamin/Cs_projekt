using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Technika
    {
        public string Nev { get; set; }
        public int EnergiaKoltseg { get; set; }

        public Technika(string nev, int energiaKoltseg)
        {
            Nev = nev;
            EnergiaKoltseg = energiaKoltseg;
        }
    }


}
