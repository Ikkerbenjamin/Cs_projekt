using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Vedelmirendszer
    {
        public string Tipus { get; private set; } // Megváltoztattuk a nevet: Tipus
        public int Ero { get; private set; }

        public Vedelmirendszer(string tipus, int ero)
        {
            Tipus = tipus; // Konstruktorban is a megfelelő nevet használjuk
            Ero = ero;
        }

        public void Erosit(Celpont celpont)
        {
            celpont.VedelemSzint += Ero;
        }
    }


}
