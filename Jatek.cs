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
        private int energia;

        public void Inditas()
        {
            Inicializalas();
            Menurendszer();
        }

        private void Inicializalas()
        {
         
            hacker = new Hacker("EliteHacker", 5, 40);

          
            celpontok = new List<Celpont>
        {
            new Celpont("Kisebb Szerver", 10),
            new Celpont("Adatbázis", 15),
            new Celpont("Banki Rendszer", 20),
            new Celpont("Fájl Kiszolgáló", 12),
            new Celpont("Weboldal", 8),
            new Celpont("Zárt Hálózat", 25)
        };
        }

        private void Menurendszer()
        {
            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

              
                Console.SetCursorPosition(100, 0);
                Console.WriteLine($"Energia: {hacker.Energia}");
                Console.ResetColor();

                Console.WriteLine("--- Hacker Támadás Szimuláció ---\n");
                Console.WriteLine("1. Energia szerzés");
                Console.WriteLine("2. Hackelési kísérlet");
                Console.WriteLine("3. Kilépés\n");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Energia Szerzés ---\n");
            Console.ResetColor();

            string[] szimbólumok = { "@", "#", "&", "*"};
            Random random = new Random();
            int helyesIndex = random.Next(szimbólumok.Length); 

         
            Console.WriteLine("Találd meg a helyes szimbólumot a következő listából, hogy energiát szerezz:");
            for (int i = 0; i < szimbólumok.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {szimbólumok[i]}");
            }

    
            Console.Write("Válaszd ki a helyes szimbólum számát (1-4): ");
            if (int.TryParse(Console.ReadLine(), out int valasztottIndex) && valasztottIndex >= 1 && valasztottIndex <= 4)
            {
                if (valasztottIndex - 1 == helyesIndex)
                {
                    hacker.Energia += 10; 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Helyes válasz! 10 energia hozzáadva.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Helytelen válasz. Próbáld újra.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen választás. Próbáld újra.");
            }

            Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
            Console.ReadKey();
        }

        private void HackelesiKiserlet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Hackelési Kísérlet ---\n");
            Console.ResetColor();

           
            Console.WriteLine("Célpontok:");
            for (int i = 0; i < celpontok.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {celpontok[i].Nev} (Védelem: {celpontok[i].VedelemSzint})");
            }

            Console.Write("Válaszd ki a célpontot (1-{0}): ", celpontok.Count);

            int celpontIndex;
            if (!int.TryParse(Console.ReadLine(), out celpontIndex) || celpontIndex < 1 || celpontIndex > celpontok.Count)
            {
                Console.WriteLine("Érvénytelen célpont.");
                return;
            }

            Celpont celpont = celpontok[celpontIndex - 1];

            
            if (hacker.Energia < celpont.VedelemSzint)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nincs elég energiád a hackeléshez!");
                Console.ResetColor();
                return;
            }

          
            if (MatematikaiJatek())
            {
                celpontok.Remove(celpont); 
                hacker.Energia -= celpont.VedelemSzint; 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Sikeresen feltörted a {celpont.Nev}-t!");
                Console.ResetColor();
            }
            else
            {
                hacker.Energia -= celpont.VedelemSzint;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A hackelés nem sikerült. Elvesztettél {celpont.VedelemSzint} energiát!");
                Console.ResetColor();
            }

            
            if (celpontok.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nMinden célpontot sikeresen feltörtél! Gratulálok!");
                Console.ResetColor();
            }

            Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
            Console.ReadKey();
        }

        private bool MatematikaiJatek()
        {
            Random random = new Random();
            int a = random.Next(1, 20);
            int b = random.Next(1, 20);
            int eredmeny;
            string muvelet = random.Next(0, 4) switch
            {
                0 => "+",
                1 => "-",
                2 => "*",
                3 => "/",
                _ => "+"
            };

            Console.WriteLine($"Mennyi {a} {muvelet} {b}?");

            bool sikeres = false;
            if (muvelet == "+") eredmeny = a + b;
            else if (muvelet == "-") eredmeny = a - b;
            else if (muvelet == "*") eredmeny = a * b;
            else eredmeny = a / b;

            Console.Write("Írd be a választ: ");
            int valasz;
            if (int.TryParse(Console.ReadLine(), out valasz) && valasz == eredmeny)
            {
                sikeres = true;
            }

            return sikeres;
        }
    }

}

