using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    public class Jatek
    {
        private Hacker hacker;
        private List<Celpont> celpontok;
        private List<Technika> technikak;

        public Jatek(List<Celpont> celpontok)
        {
            this.celpontok = celpontok;
        }

        public void Inditas()
        {
            Inicializalas();
            Menurendszer();
        }

        private void Inicializalas()
        {
            // Hacker létrehozása
            hacker = new Hacker("EliteHacker", 5, 100);

            // Hackelési technikák létrehozása
            technikak = new List<Technika>
        {
            new Technika("Brute Force", 5, 10),
            new Technika("SQL Injection", 10, 15),
            new Technika("Zero-Day Exploit", 20, 25)
        };
        }

        private void Menurendszer()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Hacker Támadás Szimuláció ---\n");
                Console.ResetColor();

                Console.WriteLine($"Aktuális energia: {hacker.Energia} / 100");
                Console.WriteLine("1. Hackelési kísérlet");
                Console.WriteLine("2. Energia feltöltése");
                Console.WriteLine("3. Kilépés\n");
                Console.Write("Választás: ");

                string valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "1":
                        HackelesiMenet();
                        break;
                    case "2":
                        EnergiaFeltoltes();
                        break;
                    case "3":
                        Console.WriteLine("Köszönjük, hogy játszottál!");
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás. Próbáld újra!");
                        break;
                }

                Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
                Console.ReadKey();
            }
        }

        private void EnergiaFeltoltes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Energia Feltöltés ---");
            Console.ResetColor();

            // Energia gyűjtése
            Console.WriteLine("Válassz egy tevékenységet az energiád feltöltéséhez:");
            Console.WriteLine("1. Minijáték a teljes energia feltöltéséhez");
            Console.WriteLine("2. Kilépés");

            string valasztas = Console.ReadLine();

            switch (valasztas)
            {
                case "1":
                    Console.WriteLine("Minijáték: Kattints a megfelelő számra!");
                    Random rand = new Random();
                    int randomSzam = rand.Next(1, 6); // 1-5 közötti szám
                    Console.WriteLine($"A szám: {randomSzam}");
                    Console.Write("Válassz számot (1-5): ");
                    if (int.TryParse(Console.ReadLine(), out int valasztottSzam) && valasztottSzam == randomSzam)
                    {
                        hacker.EnergiatTolteni(50);
                        Console.WriteLine("Sikerült a minijáték! 50 energia hozzáadva.");
                    }
                    else
                    {
                        Console.WriteLine("Minijáték nem sikerült.");
                    }
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Érvénytelen választás!");
                    break;
            }
        }

        private void HackelesiMenet()
        {
            if (celpontok.Count == 0)
            {
                Console.WriteLine("Gratulálok! Minden célpontot sikeresen feltörtél!");
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Hackelési Kísérlet ---\n");
            Console.ResetColor();

            // Célpont kiválasztása
            Console.WriteLine("Célpontok:");
            for (int i = 0; i < celpontok.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {celpontok[i].Nev} (Védelem: {celpontok[i].VedelemSzint})");
            }
            Console.Write("Válaszd ki a célpontot (1-{celpontok.Count}): ");

            if (!int.TryParse(Console.ReadLine(), out int celpontIndex) || celpontIndex < 1 || celpontIndex > celpontok.Count)
            {
                Console.WriteLine("Érvénytelen célpont!");
                return;
            }

            Celpont celpont = celpontok[celpontIndex - 1];

            // Technika kiválasztása
            Console.WriteLine("\nElérhető Hackelési Technikák:");
            for (int i = 0; i < technikak.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {technikak[i].Nev} (Erő: {technikak[i].Ero}, Energiaigény: {technikak[i].EnergiaIgeny})");
            }
            Console.Write("Válaszd ki a technikát (1-{technikak.Count}): ");

            if (!int.TryParse(Console.ReadLine(), out int technikaIndex) || technikaIndex < 1 || technikaIndex > technikak.Count)
            {
                Console.WriteLine("Érvénytelen technika!");
                return;
            }

            Technika technika = technikak[technikaIndex - 1];

            // Hackelési kísérlet végrehajtása
            bool siker = hacker.HackelesiKiserlet(celpont, technika);

            if (siker)
            {
                celpont.Gyengites(technika.Ero);

                if (celpont.VedelemSzint <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Gratulálok! Sikeresen feltörted a(z) {celpont.Nev}-t!");
                    Console.ResetColor();
                    celpontok.Remove(celpont);
                }
            }
        }
    }

}

