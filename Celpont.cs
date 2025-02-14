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
        public int VedelemSzint { get; private set; }

        public Celpont(string nev, int vedelemSzint)
        {
            Nev = nev;
            VedelemSzint = vedelemSzint;
        }

        public void Erosites(int ero)
        {
            VedelemSzint += ero;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Nev} védelmi szintje megnövekedett: +{ero}. Aktuális védelem: {VedelemSzint}");
            Console.ResetColor();
        }

        public void Gyengites(int ero)
        {
            VedelemSzint -= ero;
            if (VedelemSzint < 0) VedelemSzint = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Nev} védelmi szintje csökkent: -{ero}. Aktuális védelem: {VedelemSzint}");
            Console.ResetColor();
        }
    }


}
