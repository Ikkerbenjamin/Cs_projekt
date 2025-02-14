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
        public int Energia { get; private set; }

        public Hacker(string nev, int kepessegSzint, int energia)
        {
            Nev = nev;
            KepessegSzint = kepessegSzint;
            Energia = energia;
        }

        public bool HackelesiKiserlet(Celpont celpont, Technika technika)
        {
            if (Energia < technika.EnergiaIgeny)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nincs elég energia a támadáshoz!");
                Console.ResetColor();
                return false;
            }

            Energia -= technika.EnergiaIgeny;

            // Minijáték szimuláció
            Random rand = new Random();
            int jatekEredmeny = rand.Next(1, 11); // 1-10 között
            bool sikeres = jatekEredmeny > 5; // Ha 6 vagy nagyobb, sikeres

            if (sikeres)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sikeres hackelés!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hackelés sikertelen.");
                Console.ResetColor();
            }

            return sikeres;
        }

        public void EnergiatTolteni(int mennyiseg)
        {
            Energia += mennyiseg;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Energia feltöltve: +{mennyiseg}. Aktuális energia: {Energia}");
            Console.ResetColor();
        }
    }


}
