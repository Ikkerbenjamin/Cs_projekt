using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Celpont
    {
        public string Nev { get; private set; }
        public int VedelemSzint { get; set; }

        public Celpont(string nev, int vedelemSzint)
        {
            Nev = nev;
            VedelemSzint = vedelemSzint;
        }
    }



}
