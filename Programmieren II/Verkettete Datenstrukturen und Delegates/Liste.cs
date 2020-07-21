

namespace Verkettete_Datenstrukturen_und_Delegates
{
    public delegate bool Auswahl(int anzahl);
    class Liste
    {
        class LElement
        {
            public string name;
            public int anzahl;
            public LElement next;
            public LElement(string name, int anzahl)
            {
                this.name = name;
                this.anzahl = anzahl;
            }
        }
        LElement root;
        public void Hinzufügen(string name, int anzahl)
        {
            if (!SucheArtikel(name, anzahl))
            {
                //Vorne einfügen:
                LElement neu = new LElement(name, anzahl);
                neu.next = root;
                root = neu;
            }
        }
        /// <summary>
        /// Ist der Name in der Liste vorhanden wird die Anzahl im LElement erhöht
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Name gefunden und anzahl erhöht oder nicht gefunden</returns>
        private bool SucheArtikel(string name, int anzahl)
        {
            for (LElement tmp = root; tmp != null; tmp = tmp.next)
            {
                if (tmp.name == name)
                {
                    tmp.anzahl += anzahl;
                    return true;
                }
            }
            return false;
        }
        public Liste Bestellung(Auswahl a)
        {
            Liste l = new Liste();
            for (LElement tmp = root; tmp != null; tmp = tmp.next)
            {
                if (a(tmp.anzahl))
                    l.Hinzufügen(tmp.name, tmp.anzahl);
            }
            return l;
        }
        public override string ToString()
        {
            string s = "";
            for (LElement tmp = root; tmp != null; tmp = tmp.next)
            {
                s += $"Name: {tmp.name}, Anzahl: {tmp.anzahl}\n";
            }
            return s;
        }
    }
}
