using System;
/*#21
 Дані два числа k1 і k2 і матриця розміру 4 x 10. Поміняти місцями 
рядки (стовпчики) матриці з номерами k1 і k2. 

 */


namespace Sol_Lab_5
{
    class Program
    {
        public static void Swap(ref int[,] Matrix, int k1, int k2, bool IsRows)
        {
            if (IsRows == true)
            {
                int[] TempArr = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    TempArr[i] = Matrix[k2,i];
                }
                for (int i = 0; i < 10; i++)
                {
                    Matrix[k2, i] = Matrix[k1, i];
                }
                for (int i = 0; i < 10; i++)
                {
                    Matrix[k1, i] = TempArr[i];
                }
            }
            else
            {
                int[] TempArr = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    TempArr[i] = Matrix[i,k2];    
                }
                for (int i = 0; i < 4; i++)
                {
                    Matrix[i, k2] = Matrix[i, k1];
                }
                for (int i = 0; i < 4; i++)
                {
                    Matrix[i, k1] = TempArr[i];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{Matrix[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[,] Matrix = new int[4,10];
            int k1 = 0, k2 = 0;
            bool IsRows = true;
            try
            {
                while (true)
                {
                    Console.WriteLine("There are rows? Than enter true.");
                    IsRows = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Enter k1 and k2");
                    k1 = Convert.ToInt32(Console.ReadLine());
                    k2 = Convert.ToInt32(Console.ReadLine());
                    if (((k1 < 10 && k1 > -1) && (k2 < 10 && k2 > -1)) && IsRows == false) { break; }
                    else if (((k1 < 4 && k1 > -1) && (k2 < 4 && k2 > -1)) && IsRows == true) { break; }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matrix[i, j] = i*10 + j;
                }
            }
            Swap(ref Matrix, k1, k2, IsRows);
            /*
            Swap(ref Matrix, 0, 3, true);
            Console.WriteLine("=============");
            Swap(ref Matrix, 3, 0, false);
            */
        }
    }
}
