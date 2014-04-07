using System;

namespace w6_LinearSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int Location;
            Console.Write("enter your number: ");
            int x = int.Parse(Console.ReadLine());
            int i = 0;
            // array input
            for (int j = 0; j <= 4; j++)
            {
                Console.Write("number {0}: ", j + 1);
                string Str = Console.ReadLine();
                array[j] = int.Parse(Str);
            }
            while(i <= 4 && x != array[i])
            {
                i++;
            }
            if(i <= 4)
            {
                Location = i+1;
            }else{
                Location = 0;
            }

            for (int j = 0; j <= 4; j++)
            {
                Console.Write("{0}, ", array[j]);
            }
            Console.WriteLine();
            Console.WriteLine("Location of your number: {0}", Location);
            Console.ReadLine();
        }
    }
}


