using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Verein meinVerein = new Verein();
            meinVerein.NeuZugang += (liste, mitglied) => liste.FindAll(m => m.Alter > mitglied.Alter).ForEach(i => Console.WriteLine($"{i}"));
            meinVerein.Eintreten(new Mitglied("Klaus", 33, 120));
            meinVerein.Eintreten(new Mitglied("Sepp", 63, 70));
            meinVerein.Eintreten(new Mitglied("Ernst", 73, 200));
            meinVerein.Eintreten(new Mitglied("Max", 23, 100));
            meinVerein.Eintreten(new Mitglied("Micha", 43, 80));
        }
    }
}
