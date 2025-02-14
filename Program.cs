namespace Cs_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Szimulacio szimulacio = new Szimulacio();

            Console.WriteLine("--- Hacker Támadás Szimuláció ---");
            szimulacio.Beallitas();

            Console.WriteLine("\nA szimuláció indítása...");
            szimulacio.SzimulacioInditas();

            Console.WriteLine("\nSzimuláció befejeződött.");
        }
    }
}
