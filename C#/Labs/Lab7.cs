using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab7
{
    class Program
    {  
        static void Main(string[] args)
        {

            List<int> List = new List<int>(0);

            DoList(ref List);
            ShowSeries(List);
            DeleteIndex(ref List);

            Console.WriteLine("List with deleted prime index (2,3,5,7,11..): ");
            foreach(int i in List)
            {
                Console.Write($"{i} ");
            }
        }
        static void DoList(ref List<int> List)
        {
            bool whiledo;
            do
            {
                whiledo = false;
                Console.WriteLine("Write your list with 1 or 2, use ' ' for split");
                string Line = Console.ReadLine()!;

                string[] NumLines = Line.Split(' ');
                int num = 0;
                foreach (string l in NumLines)
                {
                    num = Int32.Parse(l);
                    if (num != 1 && num != 2)
                    {
                        Console.WriteLine("Your list is unacceptable. Try again");
                        whiledo = true;
                        List.Clear();
                        break;
                    }
                    else
                    {
                        List.Add(num);
                    }
                }
            } while (whiledo);

        }
        static void ShowSeries(List<int> List) 
        {
            Console.WriteLine("Series in List: ");
            bool isseria = false;
            for (int i = 0; i < List.Count; i++)
            {
                if (i == List.Count - 1)
                {
                    if (isseria)
                    {
                        Console.Write($"{List[i]} ");
                    }
                }
                else
                {
                    if (List[i] == List[i + 1])
                    {
                        Console.Write($"{List[i]} ");
                        isseria = true;
                    }
                    else if (List[i] != List[i + 1] && isseria == true)
                    {
                        Console.Write($"{List[i]} ");
                        isseria = false;
                    }
                    else
                    {
                        isseria = false;
                    }
                }
            }
            Console.Write("\n");
        }
        static void DeleteIndex(ref List<int> List)
        {
            for (int i = 0; i < List.Count; i++) if (IsPrime(i)) List[i] = 0;            
            List.RemoveAll(number => number == 0);
        }
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            int limit = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= limit; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

    }
}