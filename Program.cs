namespace Cs_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Hacker Támadás Szimuláció ---\n");
            Console.ResetColor();

            // Célpontok és technikák inicializálása
            List<Celpont> celpontok = new List<Celpont>
            {
                new Celpont("Kisebb Szerver", 10),
                new Celpont("Adatbázis", 20),
                new Celpont("Banki Rendszer", 30)
            };

            // Szimuláció inicializálása
            Szimulacio szimulacio = new Szimulacio(celpontok);
            szimulacio.VedelemErositesTimer();
            szimulacio.DinamikusEsemények();

            // Játék inicializálása és indítása
            Jatek jatek = new Jatek();
            jatek.Inditas();
        }
    }
}
