using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace Lab6
{
    class Program
    {
        static void Revert(int Input)
        {
            if(Input < 0)
            {
                Console.Write("-");
                Input *= -1;
            }
            if((Input > 0 && Input < 10) || Input == 0)
            {
                Console.Write(Input);
            }
            else
            {
                Console.Write(Input % 10);                
                Revert((Input - Input % 10) / 10);
            }
        }

        static void Revert(double Input)
        {
            if (Input < 0)
            {
                Console.Write("-");
                Input *= -1;
            }// 123.456
            if((Input > 0 && Input < 10) || Input == 0)
            {
                Console.Write(Input);
            }
            else
            {
                string Line  = Input.ToString();
                int counter = 0;
                while (Line[counter] != ',') 
                {
                    counter++;
                }
                string Firstpart = Line.Substring(0, counter);
                Revert(Int32.Parse(Firstpart));
                Console.Write(',');
                string Secondpart = Line.Substring(counter + 1, Line.Length - 1 - counter);
                Revert(Int32.Parse(Secondpart));
            }


        }
        static void Revert(string Input)
        {//ABC.DEF -> CBA.FED
            if (Input.Length == 1)
            {
                Console.Write(Input);
                return;
            }
            int counter = 0;
            while (counter < Input.Length && (Input[counter] != '.')) 
            {
                counter++;
            }
            for(int i = 0; i < counter; i++)
            {
                Console.Write(Input[counter - 1 - i] );
            }
            if(counter == Input.Length)
            {
                return;
            }
            else
            {
                Input = Input.Substring(counter+1);
                Console.Write('.');
                Revert(Input);
            }
        }
        static void MakeArray(string Line, out int[] Array)
        {
            string[] LineSections = Line.Split(' ');
            Array = new int[LineSections.Length];
            for (int i = 0; i < LineSections.Length; i++)
            {
                Array[i] = Convert.ToInt32(LineSections[i]);
            }
        }

        static void RevertArray(ref int[] Array, out int[] RevertedArray)
        {
            RevertedArray = new int[Array.Length];
            for (int i = 0; i < Array.Length; i++)
            {
                RevertedArray[i] = Array[Array.Length - 1 - i];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("P.S. I use '.' as magic symbol, because Double can't parse " +
                "numbers with '.'\nSo, I replace it with ','\n======\n");

            Console.WriteLine("Enter int value");
            Revert(Int32.Parse(Console.ReadLine()!));
            Console.Write("\n");

            Console.WriteLine("Enter double value (Use ',')");
            Revert(Double.Parse(Console.ReadLine()!));
            Console.Write("\n");

            Console.WriteLine("Enter any line (Use '.' to split)");
            Revert(Console.ReadLine()!);
            Console.Write("\n");

            Console.WriteLine("Enter int array numbers (Use single ' ' to split)");
            
            int[] Array;
            int[] RevertedArray;
            
            MakeArray(Console.ReadLine()!, out Array);
            RevertArray(ref Array, out RevertedArray);

            Console.Write("Reverted array: |");
            foreach(int i in RevertedArray) { Console.Write($" {i} |"); }
        }
    }
}
