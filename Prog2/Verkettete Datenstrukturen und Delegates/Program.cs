using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkettete_Datenstrukturen_und_Delegates
{
    
    class Program
    {
        public delegate bool Auswahl(int anzahl);
        static void Main(string[] args)
        {
            Liste sortiment = new Liste();
            sortiment.Hinzufügen("Kaffee", 2);
            sortiment.Hinzufügen("Zucker", 4);
            sortiment.Hinzufügen("Mehl", 10);
            sortiment.Hinzufügen("Kaffee", 3);
            Console.WriteLine(sortiment);
            Liste bestellListe = sortiment.Bestellung(delegate (int anz){ return anz <= 5; } );
            //mit Lambda-Ausdruck
            Liste bestellListeLambda = sortiment.Bestellung(anz => anz <= 5);
            Console.WriteLine(bestellListe);
            Console.WriteLine(bestellListeLambda);
        }
    }
}
