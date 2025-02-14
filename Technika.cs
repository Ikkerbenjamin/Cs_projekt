using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Technika
    {
        public string Nev { get; private set; }
        public int Ero { get; private set; }
        public int EnergiaIgeny { get; private set; }

        public Technika(string nev, int ero, int energiaIgeny)
        {
            Nev = nev;
            Ero = ero;
            EnergiaIgeny = energiaIgeny;
        }
    }


}
