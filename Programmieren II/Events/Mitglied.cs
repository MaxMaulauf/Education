using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    /// <summary>
    /// Mitglied
    /// </summary>
    class Mitglied
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public int Gewicht { get; set; }
        public Mitglied(string name,int alter,int gewicht)
        {
            Name = name;
            Alter = alter;
            Gewicht = gewicht;
        }
        public override string ToString() => $"Name: {Name}, Alter: {Alter}, Gewicht: {Gewicht}";
        
    }
}
