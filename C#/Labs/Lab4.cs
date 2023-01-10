using System;
/*21 - Даний масив цілих чисел розміру N. Видалити з масиву всі елементи, що зустрічаються 
 * 1) менше двох разів; 2) більше двох разів; 3) рівно двічі; 4) рівно тричі. */

namespace Sol_Lab_4
{
    class Program
    {
        int NewArrLengthMethod(double[,] EArr, int N, int NewArrLength, int number) 
        {
            
            return NewArrLength; 
        }
        int NewArrLengthMethod(double[,] EArr, int N, int NewArrLength, int number, bool IsMore) 
        {
            if (IsMore == true) 
            {
                for (int i = 0; i < N; i++)
                {
                    if (EArr[1, i] > number) NewArrLength = N - Convert.ToInt32(EArr[1, i]);
                }
            }
            else 
            {
                for (int i = 0; i < N; i++)
                {
                    if (EArr[1, i] < number) NewArrLength = N - Convert.ToInt32(EArr[1, i]);
                }
            }
            return NewArrLength; 
        }

        static void Main(string[] args)
        {

            int N = 0;
            Console.WriteLine("Enter N:");
            try
            {
                N = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            int[] Arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Enter element {1} of Array", i);
                try
                {
                    Arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            double[,] EArr = new double[2, N];

            for (int i = 0; i < N; i++)
            {
                EArr[0, i] = 1.1;
            }

            bool repeated = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++) if (EArr[0, j] == Arr[i]) repeated = true;

                if (EArr[0, i] != Arr[i] && repeated == false) EArr[0, i] = Arr[i];

                for (int j = 0; j < N; j++) if (EArr[0, i] == Arr[j] && repeated == false) EArr[1, i]++;
                repeated = false;
            }
            //#1
            int NewArrLength = 0;
            for (int i = 0; i < N; i++)
            {
                if (EArr[1, i] < 2 ) NewArrLength = N - Convert.ToInt32(EArr[1, i]);
            }
            int[] NewArr = new int[NewArrLength];
            for (int i = 0; i < NewArrLength; i++)
            {
                if(Arr[i] == EArr[0,i] && EArr[1, i] !< 2) { NewArr[i] = Arr[i]; }
            }


            for (int i = 0; i < N; i++)
            {
                Console.Write(EArr[0, i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                Console.Write(EArr[1, i] + " ");
            }
            for (int i = 0; i < NewArrLength; i++)
            {
                Console.WriteLine(NewArr[i] + "New Array");
            }
        }
    }
    }
