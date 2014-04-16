using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            PrintBanner();
            PrintDetails();
            Console.ReadLine();
        }

        public static void PrintBanner()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("******** Lottery Numbers *********");
            Console.WriteLine("**********************************");
        }

        public static void PrintDetails()
        {
            int[] numbers = new int[6] { 0, 0, 0, 0, 0, 0};
            
            PutIndex(ref numbers);
            PrintResult(ref numbers);
        }
        public static string GetName()
        {
            Console.Write("Enter yout name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static int[] PutIndex(ref int[] numbers)
        {
            Random random = new Random(); 
            int index = 0;
            int randomNumber;
            int loop;
            
            do
            {
                randomNumber = random.Next(1, 46);
                for (loop = 0; loop < index; loop++)
                {
                    if (numbers[loop] == randomNumber)
                    {
                        break;
                    }

                }
                if (index==loop && numbers[index] != randomNumber)
                {
                    numbers[index] = randomNumber;
                    index++;
                }

            } while (index < numbers.Length);


            return numbers;
        }
        public static void PrintResult(ref int[] numbers)
        {
            Console.Write("Name : {0}, Numbers : [", GetName());

            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine("]");
        }
    }
}
