using System;

namespace w6_BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int temp;
            // get data input 
            for (int i = 0; i <= 4; i++) 
            {
                Console.Write("number {0}: ", i+1);
                string str = Console.ReadLine();
                array[i] = int.Parse(str);
            }

            // bubble sorting
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4 - i; j++)
                {
                    if(array[j] > array[j+1])
                    {
                        temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                        Console.WriteLine("i: {0}, j: {1}, array[j]: {2}, array[i]: {3}, {4}, {5}, {6}, {7}", i,j,array[j],array[0],array[1],array[2],array[3],array[4]);
                    }
                }
            }

            // output data
            for (int i = 0; i <= 4; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
