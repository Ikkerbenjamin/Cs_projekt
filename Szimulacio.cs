using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    internal class Szimulacio
    {
        private List<Technikak> Technikakk;
        private List<Vedelmirendszer> Vedelmirendszerek;
        private Hacker hacker;
        private Celpont celpont;

        public Szimulacio()
        {
            Technikakk = new List<Technikak>
            {
                new Technikak("SQL Injekció", 30),
                new Technikak("Adathalászat", 20),
                new Technikak("Brute Force", 25)
            };

            Vedelmirendszerek = new List<Vedelmirendszer>
            {
                new Vedelmirendszer("Tűzfal", 15),
                new Vedelmirendszer("Titkosítás", 20),
                new Vedelmirendszer("MI-alapú Észlelés", 25)
            };
        }

        public void Beallitas()
        {
            Console.WriteLine("Add meg a hacker nevét:");
            string hackerNev = Console.ReadLine();

            Console.WriteLine("Add meg a hacker képességszintjét (1-100):");
            int hackerKepesseg = int.Parse(Console.ReadLine());
            hacker = new Hacker(hackerNev, hackerKepesseg);

            Console.WriteLine("Add meg a célpont nevét:");
            string celpontNev = Console.ReadLine();

            Console.WriteLine("Add meg a célpont védelmi szintjét (1-100):");
            int celpontVedelem = int.Parse(Console.ReadLine());
            celpont = new Celpont(celpontNev, celpontVedelem);

            Console.WriteLine("Válassz egy védelmet a célpont megerősítéséhez:");
            for (int i = 0; i < Vedelmirendszerek.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Vedelmirendszerek[i].Tipus} (+{Vedelmirendszerek[i].Ero})");
            }

            int VedelmirendszerValasztas = int.Parse(Console.ReadLine()) - 1;
            Vedelmirendszerek[VedelmirendszerValasztas].Erosit(celpont);
            Console.WriteLine($"A célpont védelmi szintje most {celpont.VedelemSzint}");
        }

        public void SzimulacioInditas()
        {
            Console.WriteLine("Válassz egy hackelési technikát:");
            for (int i = 0; i < Technikakk.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Technikakk[i].TechnikaNev} (Erő: {Technikakk[i].Ero})");
            }

            int technikaValasztas = int.Parse(Console.ReadLine()) - 1;
            Technikak valasztottTechnika = Technikakk[technikaValasztas];

            bool siker = hacker.HackelesiKiserlet(celpont, valasztottTechnika);

            Console.WriteLine(siker
                ? "A hacker sikeresen feltörte a célpontot!"
                : "A hacker nem tudta feltörni a célpontot.");
        }
    }
}
