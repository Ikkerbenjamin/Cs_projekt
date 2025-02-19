using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{

    namespace Cs_projekt
    {

        public class Jatek
        {
            private Hacker hacker;
            private List<Celpont> celpontok;
            private Random random;

            public void Inditas()
            {
                Console.Write("Felhasználónév: ");
                string nev = Console.ReadLine();

                Inicializalas(nev);
                Menurendszer();
            }

            private void Inicializalas(string nev)
            {
                hacker = new Hacker(nev, 40);
                random = new Random();

                celpontok = new List<Celpont>
        {
            new Celpont("Weboldal (SonicWall)", 15),
            new Celpont("Kisebb Szerver (Cisco ASA)", 28),
            new Celpont("Fájl Kiszolgáló (Cisco Firepower)", 35),
            new Celpont("Adatbázis (Suricata)", 43),
            new Celpont("Zárt Hálózat (IBM QRadar)", 65),
            new Celpont("Banki Rendszer (AES-256)", 80)
        };
            }
            public void Menurendszer()
            {
                while (true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Üdvözöljük {hacker.Nev}!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Energia: {hacker.Energia}");
                    Console.ResetColor();


                    Console.WriteLine("\n--- Hacker Támadás Szimuláció ---");
                    Console.WriteLine("1. Energia szerzés");
                    Console.WriteLine("2. Hackelési kísérlet");
                    Console.WriteLine("3. Kilépés");
                    Console.Write("Válassz egy lehetőséget: ");

                    string valasztas = Console.ReadLine();
                    switch (valasztas)
                    {
                        case "1":
                            EnergiaSzerzes();
                            break;
                        case "2":
                            HackelesiKiserlet();
                            break;
                        case "3":
                            Console.WriteLine("Köszönjük, hogy játszottál!");
                            return;
                        default:
                            Console.WriteLine("Érvénytelen választás, próbáld újra.");
                            break;
                    }
                }
            }

            private void EnergiaSzerzes()
            {
                Console.Clear();
                Console.WriteLine("--- Energia Szerzés ---");

                if (MatematikaiJatek())
                {
                    int nyertEnergia = random.Next(10, 20);
                    hacker.Energia += nyertEnergia;
                    Console.WriteLine($"Helyes válasz! {nyertEnergia} energiát szereztél!");
                }
                else
                {
                    Console.WriteLine("Rossz válasz! Nem kaptál energiát.");
                }

                Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
                Console.ReadKey();
            }

            private bool MatematikaiJatek()
            {
                int eredmeny = 0;
                int a, b;
                string muvelet;


                int muveletIndex = random.Next(4);
                switch (muveletIndex)
                {
                    case 0:
                        a = random.Next(20, 100);
                        b = random.Next(10, 50);
                        eredmeny = a + b;
                        muvelet = "+";
                        break;
                    case 1:
                        a = random.Next(30, 100);
                        b = random.Next(10, a);
                        eredmeny = a - b;
                        muvelet = "-";
                        break;
                    case 2:
                        a = random.Next(5, 20);
                        b = random.Next(2, 15);
                        eredmeny = a * b;
                        muvelet = "*";
                        break;
                    case 3:
                        b = random.Next(2, 10);
                        eredmeny = random.Next(2, 15);
                        a = b * eredmeny;
                        muvelet = "/";
                        break;
                    default:
                        return false;
                }

                Console.WriteLine($"Mennyi {a} {muvelet} {b}?");
                Console.Write("Írd be a választ: ");

                return int.TryParse(Console.ReadLine(), out int valasz) && valasz == eredmeny;
            }

            private void HackelesiKiserlet()
            {
                Console.Clear();
                Console.WriteLine("--- Hackelési Kísérlet ---");
                Console.WriteLine("Célpontok:");
                for (int i = 0; i < celpontok.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {celpontok[i].Nev} -> Védelem: {celpontok[i].VedelemSzint}");
                }

                Console.Write("Válaszd ki a célpontot (1-{0}): ", celpontok.Count);
                if (!int.TryParse(Console.ReadLine(), out int celpontIndex) || celpontIndex < 1 || celpontIndex > celpontok.Count)
                {
                    Console.WriteLine("Érvénytelen célpont.");
                    return;
                }

                Celpont celpont = celpontok[celpontIndex - 1];
                Console.WriteLine($"\nVálassz egy hackelési technikát ({celpont.Nev}):");
                Console.WriteLine("1. Brute Force (15 energia, 40% esély)");
                Console.WriteLine("2. Social Engineering (25 energia, 60% esély)");
                Console.WriteLine("3. SQL Injection (40 energia, 80% esély)");
                Console.Write("Technika: ");

                string technika = Console.ReadLine();
                int sikerEsely;
                int energiaSzukseg;

                switch (technika)
                {
                    case "1":
                        sikerEsely = 40;
                        energiaSzukseg = 15;
                        break;
                    case "2":
                        sikerEsely = 60;
                        energiaSzukseg = 25;
                        break;
                    case "3":
                        sikerEsely = 80;
                        energiaSzukseg = 40;
                        break;
                    default:
                        Console.WriteLine("Érvénytelen technika!");
                        return;
                }

                if (hacker.Energia < energiaSzukseg)
                {
                    Console.WriteLine("\nNincs elég energiád a hackeléshez!");
                    Console.ReadLine();
                    return;
                }

                if (random.Next(100) < sikerEsely)
                {
                    hacker.Energia -= energiaSzukseg;

                    int temp = celpont.VedelemSzint - energiaSzukseg;

                    if (temp <= 0)
                    {
                        Console.WriteLine($"\nSikeresen feltörted a {celpont.Nev}-t!");
                        celpontok.Remove(celpont);
                    }
                    if (temp > 0)
                    {
                        celpont.VedelemSzint -= energiaSzukseg;
                        Console.WriteLine($"\nA hackelés részben sikerült, de a {celpont.Nev} védelme még mindig {celpont.VedelemSzint}. Energia: {hacker.Energia}");
                    }
                }
                else
                {
                    hacker.Energia -= energiaSzukseg;
                    Console.WriteLine($"A hackelés nem sikerült, elvesztettél {energiaSzukseg} energiát!");
                }

                if (celpontok.Count == 0)
                {
                    Console.WriteLine("Minden célpontot feltörtél!");
                }

                Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
                Console.ReadKey();
            }
        }
    }
}