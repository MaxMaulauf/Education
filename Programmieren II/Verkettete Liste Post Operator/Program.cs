using System;
using System.Collections;

namespace Verkettete_Liste_Post_Operator
{
    class Post
    {
        public string Name { get; }
        string post;
        public Post(string name, string post)
        {
            this.Name = name;
            this.post = post;
        }
        public override string ToString()
        {
            return Name + " - " + post;
        }
    }
    class List : IEnumerable
    {
        private class Element
        {
            public Post ElemPost { get; }
            public Element next/*,prev*/;
            public Element(Post post)
            {
                ElemPost = post;
            }
        }
        Element root;
        public int Count { get; private set; }
        public List()
        {
            root = null;
            Count = 0;
        }
        public override string ToString()
        {
            string str = "";
            foreach (Post item in this)
            {
                str += item;
            }
            return str;
        }
        public IEnumerator GetEnumerator()
        {
            for (Element tmp = root; tmp != null; tmp = tmp.next)
            {
                yield return tmp.ElemPost;
            }
        }
        public static List operator +(List l, Post p)
        {
            Element add = new Element(p);
            if (l.root == null)
                l.root = add;
            else
            {
                add.next = l.root;
                //l.root.prev = add;
                l.root = add;
            }
            return l;
        }
        public static List operator -(List l, string person)
        {
            while (l.root != null)
            {
                if (l.root.ElemPost.Name == person)
                {
                    l.root = l.root.next;
                    //l.root.prev = null;
                }
                else
                    break;
            }
            Element tmp = l.root;
            while (tmp.next != null)
            {
                if (tmp.next.ElemPost.Name == person)
                {
                    tmp.next = tmp.next.next;
                    //if (tmp.next != null)
                    //    tmp.next.prev = tmp;
                }
                else
                {
                    if (tmp.next != null)
                        tmp = tmp.next;
                }
            }
            return l;
        }
        public Post this[string person]
        {
            get
            {
                Post last = null;
                foreach (Post item in this)
                {
                    if (item.Name == person)
                        last = item;
                }
                return last;
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List postList = new List();
            postList += new Post("Max", "Erster!");
            postList += new Post("Peter", "Hallo?");
            postList += new Post("Max", "Klausuren sind anstrengend");
            postList += new Post("Max", "Aufgaben online");
            postList += new Post("Moritz", "Ferien sind cool");
            postList += new Post("Max", "Ferienbilder");
            Post lastPost = postList["Max"];
            if (lastPost != null)
            {
                Console.WriteLine("Last Post: " + lastPost);
            }
            postList -= "Max";
            foreach (Post post in postList)
            {
                Console.WriteLine(post);
            }
        }
    }
}
