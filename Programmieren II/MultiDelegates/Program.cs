using System;

namespace MultiDelegates
{
    public delegate void OperationDel(ref int a);
    class Program
    {
        static void Main(string[] args)
        {
            int val = 2;
            OperationDel someDel = subtract2;
            someDel += add1;
            OperationDel myDel = someDel;
            OperationDel mult2 = delegate (ref int a) { a *= 2; };
            processAndShow(myDel, val);//1
            myDel += mult2;
            processAndShow(myDel, val);//2
            myDel += subtract2;
            processAndShow(myDel, val);//0
            myDel -= subtract2;
            processAndShow(myDel, val);//2
            myDel += delegate (ref int a) { a *= 2; };
            processAndShow(myDel, val);//4
            myDel -= delegate (ref int a) { a *= 2; };
            myDel -= mult2;
            myDel -= subtract2;
            processAndShow(myDel, val);//6
            myDel -= mult2;
            processAndShow(myDel, val);//6
        }
        public static void subtract2(ref int a) { a -= a; }
        public static void add1(ref int a) { a += 1; }
        public static void processAndShow(OperationDel del, int val)
        {
            del(ref val);
            Console.Write(val + " ");
        }
    }
}
