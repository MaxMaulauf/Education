using System;
using System.Linq;

namespace Generische_Teilmenge
{
    class Student
    {
        string name;
        int matnr;
        public Student(string _name, int _matnr)
        {
            name = _name;
            matnr = _matnr;
        }
        public override bool Equals(object obj)
        {
            return name == (obj as Student).name && matnr == (obj as Student).matnr;
        }

    }
    class Program
    {
        static bool Teilmenge<T>(T[] a, T[] b)
        {
            bool result = false;
            for (int i = 0; i < b.Length; i++)
            {
                result = a.Contains(b[i]);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] a = { 8, 6, 1, 7, 4, 9 };
            int[] b = { 1, 6, 9 };
            Console.WriteLine(Teilmenge<int>(a, b));
            Student[] s1 = { new Student("a", 1), new Student("b", 2), new Student("c", 3), new Student("d", 4) };
            Student[] s2 = { new Student("b", 2), new Student("d", 4) };
            Console.WriteLine(Teilmenge<Student>(s1, s2));
        }
    }
}
