using System;

namespace Sol_Lab_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //double R, H;
            //while (true)
            //{
            //    Console.WriteLine("Enter R and H:");
            //    R = Convert.ToDouble(Console.ReadLine());
            //    H = Convert.ToDouble(Console.ReadLine());
            //    if (R > 0 && H > 0)break;
            //}
            //Console.WriteLine($"V = {Math.PI * Math.Pow(R, 2) * H}");

            int nn = -1, nk = -1;
            while (true)
            {
                Console.WriteLine("Enter nn & nk (0 <= nn <=n/k):");
                try
                {
                    nn = Convert.ToInt32(Console.ReadLine());
                    nk = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

                if (0 <= nn && nn <= nk) break;
            }
            Double Sum = 0;
            for (int k = nn; k <= nk; k++)
            {
                Sum += (k * k + Math.Pow(-1, k - 1) * 2 * k - 1) / (k * k + 2);

            }
            Console.WriteLine(Sum);
        }
    }
}
