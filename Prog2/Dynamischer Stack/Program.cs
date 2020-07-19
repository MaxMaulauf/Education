using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamischer_Stack
{
    class Program
    {
        class Stack<T>:IEnumerable
        {
            private class Element
            {
                public T content;
                public Element next;
                public Element(T content)
                {
                    this.content = content;
                }
            }
            Element root;
            public Stack()
            {

            }
            public void Push(T content)
            {
                Element add = new Element(content);
                if (root == null)
                    root = add;
                else
                {
                    add.next = root;
                    root = add;
                }
            }
            public T Pop()
            {
                if (root == null)
                    throw new ArgumentNullException();
                T result=root.content;
                root = root.next;
                return result;
            }
            public IEnumerator GetEnumerator()
            {
                for (Element tmp = root; tmp !=null; tmp=tmp.next)
                {
                    yield return tmp.content;
                }
            }
            public void Revert()
            {
                if (root == null || root.next == null)
                    return;
                Element left=null, right=root.next;
                root.next = null;
                while (right!=null)
                {
                    left = root;
                    root = right;
                    right = right.next;
                    root.next = left;
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
