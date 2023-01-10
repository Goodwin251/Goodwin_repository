namespace ForBetterscore
{
    internal class Program
    {

        class Headphone
        {
            private string brand = "";
            public string Brand { get { return brand; } set { brand = value; } }

            private int price;
            public int Price { get { return price; } set { price = value; } }

            private int year;
            public int Year { get { return year; } set { year = value; } }

            private string color = "";
            public string Color { get { return color; } set { color = value; } }


            List<Headphone> headphones = new List<Headphone>(5);

            public Headphone(string brand, string color)
            {
                Random rnd = new Random();
                Brand = brand;
                Price = rnd.Next(200, 4399);
                Year = rnd.Next(1997, 2024);
                Color = color;

            }
            public Headphone()
            {
                headphones.Add(new Headphone("Apple", "white"));
                headphones.Add(new Headphone("Sony", "blue"));
                headphones.Add(new Headphone("Ergo", "red"));
                headphones.Add(new Headphone("Razer", "green"));
                headphones.Add(new Headphone("Epos", "black"));
            }
            public void Show()
            {
                for (int i = 0; i < headphones.Count; i++)
                {
                    Console.WriteLine(headphones[i].Brand + "\t" + headphones[i].Price + "\t" + headphones[i].Year + "\t" + headphones[i].Color);
                }
            }
            public void Search()
            {
                while (true)
                {
                    Console.WriteLine("Write params to search in correct way, use ',' to split");
                    Console.WriteLine("Just skip character to skip parametr for search");

                    string Line = Console.ReadLine()!;
                    string[] segments = Line.Split(',');

                    bool isskip1 = false, isskip2 = false;

                    int TargetPrice = -1, TargetYear = -1;
                    string TargetBrand, TargetColor;
                    try
                    {
                        TargetBrand = segments[0];
                        
                        if (segments[1] == "") isskip1 = true;
                        else TargetPrice = Int32.Parse(segments[1]);
                        if (segments[2] == "") isskip2 = true;
                        else TargetYear = Int32.Parse(segments[2]);
                        TargetColor = segments[3];
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        continue;
                    }
                     Console.WriteLine($"\nTarget values: '{segments[0]}', '{segments[1]}', '{segments[2]}', '{segments[3]}'");

                    if ((TargetPrice < 0 && !isskip1) || (TargetYear < 0 && !isskip2))
                        Console.WriteLine("Impossible values");
                    else
                    {
                        bool IsTarget = false;
                        Console.WriteLine("\nFounded headphones:");
                        for (int i = 0; i < headphones.Count; i++)
                        {
                            if (((headphones[i].Brand == TargetBrand) || (TargetBrand == "")) &&
                                ((headphones[i].Price == TargetPrice) || (isskip1 == true)) &&
                                ((headphones[i].Year == TargetYear) || (isskip2 == true )) &&
                                ((headphones[i].Color == TargetColor) || (TargetColor == "")))
                            { 
                                Console.WriteLine(headphones[i].Brand + "\t" + headphones[i].Price + "\t" + headphones[i].Year + "\t" + headphones[i].Color);
                                IsTarget = true;    
                            }
                        }
                        if (!IsTarget)                      
                            Console.WriteLine("Nothing found");
                        break;
                    }
                }

            }


        }


        static void Main(string[] args)
        {
            Headphone H = new Headphone();
            H.Show();
            H.Search();
        }
    }
}