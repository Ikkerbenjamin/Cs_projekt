using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_projekt
{
    
        public class Szimulacio
        {
            private List<Celpont> celpontok;

            public Szimulacio(List<Celpont> celpontok)
            {
                this.celpontok = celpontok;
            }

            public void VedelemErositesTimer()
            {
                // Időközönként automatikusan erősíti a célpontokat
                new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(15000); // 15 másodpercenként fut

                        if (celpontok.Count > 0)
                        {
                            Random random = new Random();
                            int index = random.Next(celpontok.Count);
                            int ero = random.Next(5, 15);

                            celpontok[index].Erosites(ero);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\n[Figyelem] {celpontok[index].Nev} védelmi szintje megerősödött! (+{ero})\n");
                            Console.ResetColor();
                        }
                    }
                }).Start();
            }

            public void DinamikusEsemények()
            {
                // Véletlenszerű események hozzáadása
                new Thread(() =>
                {
                    Random random = new Random();
                    while (true)
                    {
                        Thread.Sleep(20000); // 20 másodpercenként fut

                        int esemeny = random.Next(1, 3);
                        switch (esemeny)
                        {
                            case 1:
                                // Új célpont hozzáadása
                                int vedelemSzint = random.Next(15, 25);
                                string nev = $"Új Szerver {celpontok.Count + 1}";
                                celpontok.Add(new Celpont(nev, vedelemSzint));
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n[Új célpont] {nev} hozzáadva! Védelem: {vedelemSzint}\n");
                                Console.ResetColor();
                                break;

                            case 2:
                                // Váratlan védelemcsökkenés
                                if (celpontok.Count > 0)
                                {
                                    int index = random.Next(celpontok.Count);
                                    int csokkenes = random.Next(5, 10);
                                    celpontok[index].Gyengites(csokkenes);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine($"\n[Gyengeség] {celpontok[index].Nev} védelemcsökkenést szenvedett! (-{csokkenes})\n");
                                    Console.ResetColor();
                                }
                                break;
                        }
                    }
                }).Start();
            }
        }
    }

