using System;

/*Дані координати (як цілі від 1 до 8) двох різних полів шахівниці. 
   Якщо кінь за один хід може перейти з одного поля на інше, вивести 
   логічне значення True, інакше вивести значення False.*/
namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int Sx = 0, Sy = 0, x = 0, y = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter coords of horse");
                    Sx = Convert.ToInt32(Console.ReadLine());
                    Sy = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter your wanted coords");
                    x = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if ((Sx < 9 && Sx > 0) && (Sy < 9 && Sy > 0) && (x < 9 && x > 0) && (y < 9 && y > 0)) break;
                else Console.WriteLine("Incorrect coords.");
            }
            if (x == (Sx + 1) && y == (Sy + 2) || x == (Sx + 2) && y == (Sy + 1)
            || x == (Sx + 1) && y == (Sy - 2) || x == (Sx + 2) && y == (Sy - 1)
            || x == (Sx - 1) && y == (Sy - 2) || x == (Sx - 2) && y == (Sy - 1)
            || x == (Sx - 1) && y == (Sy + 2) || x == (Sx - 2) && y == (Sy + 1))
                Console.WriteLine(true);
            else Console.WriteLine(false);

        }
    }
}
