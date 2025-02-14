using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cs_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Hacker Támadás Szimuláció ---\n");
            Console.ResetColor();

            // Célpontok inicializálása
            List<Celpont> celpontok = new List<Celpont>
        {
            new Celpont("Kisebb Szerver", 10),
            new Celpont("Adatbázis", 20),
            new Celpont("Banki Rendszer", 30),
            new Celpont("Kormányzati Rendszer", 40),
            new Celpont("Titkos Társaság", 50)
        };

            // Játék inicializálása és indítása
            Jatek jatek = new Jatek(celpontok);
            jatek.Inditas();
        }
    }

}
