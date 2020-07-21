using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    delegate void NeuesMitglied(List<Mitglied> l, Mitglied m);
    class Verein
    {
        public event NeuesMitglied NeuZugang;
        public List<Mitglied> interneListe = new List<Mitglied>();
        
        public void Eintreten(Mitglied mitglied)
        {
            NeuZugang?.Invoke(interneListe, mitglied);
            interneListe.Add(mitglied);
        }
    }
}
