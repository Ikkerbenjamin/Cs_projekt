using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    internal class Technikak
    {
        public string TechnikaNev { get; private set; }
        public int Ero { get; private set; }

        public Technikak(string technikaNev, int ero)
        {
            TechnikaNev = technikaNev;
            Ero = ero;
        }
    }
}
