using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Verkettete_Liste
{
    /// <summary>
    /// Sortierte, einfach verkettete Liste. Hier mit strings
    /// </summary>
    class List : IEnumerable
    {
        /// <summary>
        /// private Klasse für Element
        /// </summary>
        private class Element : IComparable<string>
        {
            /// <summary>
            /// Der Inhalt eines Elements. Hier könnten statt string auch jede Art von Objekt stehen. Insbesondere Objekte einer anderen Klasse außerhalb der Klasse List
            /// </summary>
            public string name;
            /// <summary>
            /// Die Anzahl dieses Elements in der Liste. Falls es keine mehrfachen Einträge geben soll
            /// </summary>
            public int Volume { get { return _volume; } set { _volume = value; } }
            private int _volume;
            /// <summary>
            /// Zeiger auf das nächste Element und der Klebstoff, der die verkettete Liste zusammenhält
            /// </summary>
            public Element next;
            /// <summary>
            /// Ein Kettenglied
            /// </summary>
            /// <param name="Name">Inhalt des Elements, hier ein String</param>
            /// <param name="volume">Anzahl wie oft der Inhalt in diesem ELement sein soll</param>
            public Element(string Name, int volume = 1) { name = Name; Volume = volume; }
            /// <summary>
            /// Element zu String
            /// </summary>
            /// <returns>Inhalt des Element</returns>
            public override string ToString()
            {
                return name;
            }
            /// <summary>
            /// Vergleicht Inhalt eines Element mit gleichem Typ insbesondere zum Einsortieren
            /// </summary>
            /// <param name="other">Objekt des Typs mit dem verglichen wird</param>
            /// <returns>Inhalt ist kleiner(-1), gleich(0) oder größer(1) als das andere</returns>
            public int CompareTo(string other)
            {
                return this.name.CompareTo(other);
            }
        }
        /// <summary>
        /// Root zeigt auf das erste Element, damit die Liste existieren kann
        /// </summary>
        Element root;
        /// <summary>
        /// Sehr praktisch um direkt ans Ende der Liste zu gelangen
        /// </summary>
        Element last;
        private int _count;
        /// <summary>
        /// Anzahl der Elemente in der Liste
        /// </summary>
        public int Count { get { return _count; } private set { _count = value; } }
        /// <summary>
        /// Erzeugt ein leere Liste
        /// </summary>
        public List()
        {
            root = last;
            Count = 0;
        }
        /// <summary>
        /// Erzeugt eine Liste mit den angegebenen parametern
        /// </summary>
        /// <param name="contents">Der Inhalt für die Elemente</param>
        public List(params string[] contents)
        {
            root = last;
            Count = 0;
            SortedUpdate(contents);
        }
        /// <summary>
        /// Liste zu String
        /// </summary>
        /// <returns>Inhalte aller Elemente der Liste</returns>
        public override string ToString()
        {
            if (root == null)
                return "Liste ist leer";
            string str = "";
            foreach (Element item in this)
            {
                str += $"Inhalt: {item.name,8}, Anzahl: {item.Volume}\n";
            }
            str += $" Count: {Count}\n";
            return str;
        }
        public string Print(int volume)
        {
            string str = "";
            foreach (Element item in this)
            {
                if (item.Volume>=volume)
                {
                    str += $"{item.name,8} {item.Volume} \n";
                }
            }
            return str;
        }
        /// <summary>
        /// Macht die Liste foreachbar
        /// </summary>
        /// <returns>Ein Element nach dem anderen</returns>
        public IEnumerator GetEnumerator()
        {
            for (Element tmp = root; tmp != null; tmp = tmp.next)
                yield return tmp;
        }
        /// <summary>
        /// Fügt ein neues Element vor dem ersten ein oder erhöht root.volume entsprechend
        /// </summary>
        /// <param name="str">Inhalt des Element, hier string</param>
        /// <param name="volume">Anzahl des Inhalt im Element, falls Elemente nicht mehrfach vorkommen sollen</param>
        private void AddFirst(string str, int volume = 1)
        {
            Element add = new Element(str, volume);
            if (root == null)
            {
                root = last = add;
                Count++;
                return;
            }
            else
            {
                if (root.name.CompareTo(str) == 0)
                {
                    root.Volume += volume;
                    return;
                }
                add.next = root;
                root = add;
                Count++;
            }
        }
        /// <summary>
        /// Fügt ein neues Element nach dem letzten ein oder erhöht last.volume entsprechend
        /// </summary>
        /// <param name="str">Inhalt des Element, hier string</param>
        /// <param name="volume">Anzahl des Inhalt im Element, falls Elemente nicht mehrfach vorkommen sollen</param>
        private void AddLast(string str, int volume = 1)
        {
            Element add = new Element(str, volume);
            if (root == null)
            {
                root = last = add;
            }
            else
            {
                last.next = add;
                last = add;
            }
            Count++;
        }
        /// <summary>
        /// Sortiert einen neuen Inhalt in die Liste ein
        /// </summary>
        /// <param name="str">Inhalt zum einsortieren, hier string</param>
        /// <param name="volume">Anzahl wie oft der Inhalt im Element sein soll, falls gleiche Elemente nicht mehrfach vorkommen sollen</param>
        public void SortedUpdate(params string[] texts)
        {
            foreach (string item in texts)
            {
                if (root == null || root.name.CompareTo(item) >= 0)
                {
                    AddFirst(item);
                }
                else if (last.name.CompareTo(item) <= 0)
                {
                    AddLast(item);
                }
                else
                {
                    Element add = new Element(item);
                    for (Element tmp = root; tmp != last; tmp = tmp.next)
                    {
                        if (tmp.next.name.CompareTo(item) == 0)
                        {
                            tmp.next.Volume++;
                            break;
                        }
                        else if (tmp.next.name.CompareTo(item) > 0)
                        {
                            add.next = tmp.next;
                            tmp.next = add;
                            Count++;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Löscht das Element mit dem entsprechenden Inhalt oder reduziert volume entsprechend
        /// </summary>
        /// <param name="str">Ihalt des zu löschendne Elements</param>
        /// <returns>true, wenn gelöscht oder reduziert, false, wenn nicht in Liste oder Liste leer</returns>
        public bool Remove(string str,int amount=0)
        {
            if (root == null)
                return false;
            if (root.name.CompareTo(str) == 0)
            {
                root.Volume -= amount;
                if (amount == 0|| root.Volume < 1)
                {
                    root = root.next;
                    Count--;
                }
                return true;
            }
            Element tmp;
            for (tmp = root; tmp != last; tmp = tmp.next)
            {
                if (tmp.next.name.CompareTo(str) == 0)
                    break;
            }
            if (tmp==last)
            {
                return false;
            }
            tmp.next.Volume -= amount;
            if (amount == 0 || tmp.next.Volume < 1)
            {
                tmp.next = tmp.next.next;
                Count--;
            }
            if (tmp.next == null)
            {
                last = tmp;
            }
            return true;
        }
        /// <summary>
        /// Löscht das Element an der Position bzw. reduziert volume entsprechend
        /// </summary>
        /// <param name="index">Zu löschende Position in der Liste</param>
        /// <param name="amount">Zu löschende Anzahl</param>
        /// <returns></returns>
        public bool RemoveAt(int index, int amount = 0)
        {
            if (root == null)
                return false;
            if (index == 0)
            {
                root.Volume -= amount;
                if (amount == 0 || root.Volume < 1)
                {
                    root = root.next;
                    Count--;
                }
                return true;
            }
            Element tmp = Nth(index - 1);
            if (tmp == null||tmp==last)
                return false;
            tmp.next.Volume -= amount;
            if (amount == 0 || tmp.next.Volume < 1)
            {
                tmp.next = tmp.next.next;
                Count--;
            }
            if (tmp.next == null)
            {
                last = tmp;
            }
            return true;
        }
        /// <summary>
        /// Indexer zum Abrufen des Inhalts des Elements an der angegebenen Position. Kein set
        /// </summary>
        /// <param name="index">Position des Elements</param>
        /// <returns>Inhalt des Elements an der Position</returns>
        public string this[int index]
        {
            get { return Nth(index)?.name; }
        }
        /// <summary>
        /// Dreht die Reihenfolge der Liste um
        /// </summary>
        public void Reverse()
        {
            Element left = null, right = root.next;
            last = root;
            root.next = null;
            while (right != null)
            {
                left = root;
                root = right;
                right = right.next;
                root.next = left;
            }
        }
        /// <summary>
        /// Erzeugt eine neue Liste mit Elementen, die dem Filter entsprechen
        /// </summary>
        /// <param name="pattern">String nach dem gefiltert wird</param>
        /// <returns></returns>
        public List Filter(string pattern)
        {
            List tmpList = new List();
            foreach (Element item in this)
            {
                if (item.name.Contains(pattern))
                    tmpList.AddLast(item.name,item.Volume);
            }
            return tmpList;
        }
        /// <summary>
        /// Hilfsfunktion gibt das xte Element zurück
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Das Xte Element</returns>
        private Element Nth(int n)
        {
            int index=0;
            foreach (Element item in this)
            {
                if (index==n)
                {
                    return item;
                }
                index++;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List L1 = new List();
            string[] arr = { "Max", "Müller", "Xaver", "Meier", "Alfons", "Berta" };
            L1.SortedUpdate(arr);
            Console.WriteLine(L1);
            Console.WriteLine(L1[5]);
            L1.SortedUpdate("Max");
            Console.WriteLine(L1.Print(2));
            Console.WriteLine(L1.Filter("M"));
            L1.Remove("Xaver", 1);
            L1.RemoveAt(1);
            Console.WriteLine(L1);
            L1.Reverse();
            Console.WriteLine(L1);

        }
    }
}
