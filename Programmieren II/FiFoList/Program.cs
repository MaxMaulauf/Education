using System;

namespace FiFoList
{
    class Program
    {
        static void Main(string[] args)
        {
            FiFoList<int> mylist = new FiFoList<int>();
            mylist.AddFirst(20);
            mylist.AddFirst(10);
            mylist.AddFirst(5);
            Console.WriteLine(mylist);
            FiFoList<int> newlist = mylist.FindAll(a => a.CompareTo(5) >= 0 && a.CompareTo(10) <= 0);
            Console.WriteLine(newlist);
        }
    }
}
