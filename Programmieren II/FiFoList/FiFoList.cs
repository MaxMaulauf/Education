using System;
using System.Collections;

namespace FiFoList
{
    class FiFoList<T> : IEnumerable where T : IComparable
    {
        class LItem
        {
            public T data { get; }
            public LItem next;
            public LItem(T data)
            {
                this.data = data;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (LItem item in this)
            {
                s += item.data+"\n";
            }
            return s;
        }
        LItem root;
        public IEnumerator GetEnumerator()
        {
            for(LItem tmp = root; tmp != null; tmp = tmp.next)
            {
                yield return tmp;
            }
        }
        public void AddFirst(T data)
        {
            LItem newItem = new LItem(data);
            newItem.next = root;
            root = newItem;
        }
        public T GetMaxItem()
        {
            if (root == null)
                throw new ArgumentNullException();
            T max = root.data;
            LItem current = root;
            while (current != null)
            {
                if (current.data.CompareTo(max) > 0)
                    max = current.data;
                current = current.next;
            }
            return max;
        }
        public delegate bool Filter(T data);
        public FiFoList<T> FindAll(Filter f)
        {
            FiFoList<T> filter = new FiFoList<T>();
            foreach (LItem item in this)
            {
                if (f(item.data))
                    filter.AddFirst(item.data);
            }
            return filter;
        }
    }
}
