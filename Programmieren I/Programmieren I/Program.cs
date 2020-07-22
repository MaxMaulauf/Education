using System;

namespace Programmieren_I
{
    class Program
    {
        /// <summary>
        /// Sorts the array in ascending order
        /// </summary>
        /// <param name="array"></param>
        public static void SortArrayAsc(int[] array)
        {
            int min;
            for (int k = 0; k < array.Length - 1;k++)
            {
                min = array[k];
                for (int i = k+1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        array[i] = array[k];
                        array[k] = min;
                    }
                } 
            }
        }
        /// <summary>
        /// Sorts array in descending order
        /// </summary>
        /// <param name="array"></param>
        public static void SortArrayDesc(int[] array)
        {
            int max;
            for (int k = 0; k < array.Length - 1; k++)
            {
                max = array[k];
                for (int i = k + 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        array[i] = array[k];
                        array[k] = max;
                    }
                }
            }
        }
        /// <summary>
        /// Greatest Value in array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Greatest value</returns>
        public static int MaxValue(int[] array)
        {
            int max=array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        /// <summary>
        /// Lowest value in array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>lowest value</returns>
        public static int MinValue(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
        public static int MaxIndex(int[] array)
        {
            int max = array[0], index=0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
        public static int MinIndex(int[] array)
        {
            int min = array[0], index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }
        public static int FindIndex(int[] array,int quest)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == quest)
                    return i;
            }
            return -1;
        }
        public static int MinIndex2(int[] array)
        {
            return FindIndex(array, MinValue(array));
        }
        public static int MaxIndex2(int[] array)
        {
            return FindIndex(array, MaxValue(array));
        }
        /// <summary>
        /// Reverses the order of the array
        /// </summary>
        /// <param name="array"></param>
        public static void Reverse(int[] array)
        {
            int aux;
            for (int i = 0; i < array.Length/2; i++)
            {
                aux = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = aux;
            }
        }
        /// <summary>
        /// Shortens the array deleting the amount of Elements starting at 0
        /// </summary>
        /// <param name="array"></param>
        /// <param name="amount"></param>
        public static void SkipRef(ref int[] array,int amount)
        {
            int[] aux = new int[array.Length-amount];
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = array[i+amount];
            }
            array = aux;
        }
        /// <summary>
        /// Writes a new array without the first amount of Elements
        /// </summary>
        /// <param name="array"></param>
        /// <param name="amount"></param>
        /// <returns>new shortened array</returns>
        public static int[] Skip(int[] array,int amount)
        {
            int[] aux = new int[array.Length - amount];
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = array[i + amount];
            }
            return aux;
        }
        static void Main(string[] args)
        {
            int[] testArray = { 4, 2, 6, 3, 1, 7, 5, 8, 12, 9 };
            Console.WriteLine("Original");
            foreach (var item in testArray)
            {
                Console.Write(" "+item);
            }
            Console.WriteLine("\nSortAsc");
            SortArrayAsc(testArray);
            foreach (var item in testArray)
            {
                Console.Write(" " + item);
            }
            SortArrayDesc(testArray);
            Console.WriteLine("\nSortDesc");
            foreach (var item in testArray)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine("\nMaxValue");
            Console.WriteLine(MaxValue(testArray));
            Console.WriteLine("MinValue");
            Console.WriteLine(MinValue(testArray));
            Reverse(testArray);
            Console.WriteLine("Reverse");
            foreach (var item in testArray)
            {
                Console.Write(" " + item);
            }
            SkipRef(ref testArray,3);
            Console.WriteLine("\nSkipRef");
            foreach (var item in testArray)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine("\nSkip");
            foreach (var item in Skip(testArray,3))
            {
                Console.Write(" " + item);
            }
        }
    }
}
