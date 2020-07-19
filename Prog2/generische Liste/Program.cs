using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace generische_Liste
{
    class StackAndOrderedList<T> where T : IComparable
    {
        ChainList stack = new ChainList();
        ChainList ordered = new ChainList();
        public void Add(T content)
        {
            stack.AddFirst(content);
            ordered.SortedUpdate(content);
        }
        public override string ToString()
        {
            return stack.ToString()+ ordered.ToString();
        }
        public string this[int index]
        {
            get
            {
                return stack.Nth(index).ToString();
            }
        }
        private class ChainList : IEnumerable
        {
            public T Nth(int n)
            {
                int index = 0;
                foreach (Element item in this)
                {
                    if (index == n)
                    {
                        return item.content;
                    }
                    index++;
                }
                throw new IndexOutOfRangeException();
            }
            private class Element : IComparable<T>
            {
                public T content;
                public Element next;
                public Element(T Content) { content = Content;}
                public int CompareTo(T other)
                {
                    return this.content.CompareTo(other);
                }
                public override string ToString()
                {
                    return content.ToString();
                }
            }
            Element root;
            Element last;
            public ChainList()
            {
                root = last;
            }
            public ChainList(params T[] contents)
            {
                root = last;
                SortedUpdate(contents);
            }
            public override string ToString()
            {
                if (root == null)
                    return "Liste ist leer";
                string str = "";
                foreach (Element item in this)
                {
                    str += $"{item.content,8}\n";
                }
                return str;
            }
            public IEnumerator GetEnumerator()
            {
                for (Element tmp = root; tmp != null; tmp = tmp.next)
                    yield return tmp;
            }
            public void AddFirst(T content)
            {
                Element add = new Element(content);
                if (root == null)
                {
                    root = last = add;
                }
                else
                {
                    add.next = root;
                    root = add;
                }
            }
            private void AddLast(T content)
            {
                Element add = new Element(content);
                if (root == null)
                {
                    root = last = add;
                }
                else
                {
                    last.next = add;
                    last = add;
                }
            }
            public void SortedUpdate(params T[] contents)
            {
                foreach (T item in contents)
                {
                    if (root == null || root.content.CompareTo(item) >= 0)
                    {
                        AddFirst(item);
                    }
                    else if (last.content.CompareTo(item) <= 0)
                    {
                        AddLast(item);
                    }
                    else
                    {
                        Element add = new Element(item);
                        for (Element tmp = root; tmp != last; tmp = tmp.next)
                        {
                            if (tmp.next.content.CompareTo(item) >= 0)
                            {
                                add.next = tmp.next;
                                tmp.next = add;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StackAndOrderedList<string> liste = new StackAndOrderedList<string>();
            liste.Add("Gabi ");
            liste.Add("Hans ");
            liste.Add("Anton ");
            liste.Add("Lisa ");
            Console.WriteLine(liste);
            Console.WriteLine(liste[0]);
        }
    }
}
