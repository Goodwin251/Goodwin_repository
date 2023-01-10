using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab8
{
    class Program
    {
        //Перше завдання
        public class Sheikh
        {
            private class Auto
            {
                private string _name = "";
                public string Name
                {
                    get { return _name; }
                    set { _name = value; }
                }
                private string _color = "";
                public string Color
                {
                    get { return _color; }
                    set { _color = value; }
                }

                private int _speed;
                public int Speed
                {
                    get { return _speed; }
                    set { _speed = value; }
                }

                private int _year;
                public int Year
                {
                    get { return _year; }
                    set { _year = value; }
                }

                public Auto(string name, string color, int speed, int year)
                {
                    _name = name;
                    _color = color;
                    _speed = speed;
                    _year = year;
                }
                public Auto()
                {
                    bool doing = true;
                    do
                    {
                        doing = false;

                        Console.WriteLine("\nEnter new car name");

                        _name = Console.ReadLine()!;
                        if (_name == "")
                        {
                            Console.WriteLine("You should write something");
                            doing = true;
                            continue;
                        }
                        Console.WriteLine("Enter color");
                        _color = Console.ReadLine()!;
                        if (_color == "")
                        {
                            Console.WriteLine("You should write something");
                            doing = true;
                            continue;
                        }
                        Console.WriteLine("Enter speed (kmph)");
                        try
                        {
                            _speed = Int32.Parse(Console.ReadLine()!);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            doing = true;
                            continue;
                        }

                        Console.WriteLine("Enter year");
                        try
                        {
                            _year = Int32.Parse(Console.ReadLine()!);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            doing = true;
                            continue;
                        }

                    } while (doing);
                    Console.WriteLine($"\nNew car added: {this._name} | " +
                        $"{this._color} | {this._speed} kmph | {this._year} |");

                }
            }

            public class Garage
            {
                List<Auto> Sheikh_auto = new List<Auto>(3)
            {
                new Auto("Porshe Panomera", "white", 250, 2022),
                new Auto("BMW 7-Series", "black", 250, 2022),
                new Auto("Chevrolet Corvette", "red", 330, 2022)
            };
                private void List()
                {
                    Console.WriteLine("\n| Name | Speed | Color | Year |");
                    for (int i = 0; i < Sheikh_auto.Count; i++)
                    {
                        Console.WriteLine($"| {Sheikh_auto[i].Name} | {Sheikh_auto[i].Color} " +
                            $"| {Sheikh_auto[i].Speed} | {Sheikh_auto[i].Year} |");
                    }
                    Console.WriteLine($"\nCount: {Sheikh_auto.Count}");
                }
                private void Delete()
                {
                    Console.WriteLine($"\nDelete one of your car ");

                    List();

                    string[] Answers = new string[4];
                    while (true)
                    {
                        Console.WriteLine("\nWrite parametrs in line, split them with ';'");
                        string Line = Console.ReadLine()!;

                        string[] Values = Line.Split(';');
                        if (Values.Length == 4)
                        {
                            try
                            {
                                Int32.Parse(Values[2]);
                                Int32.Parse(Values[3]);

                                Answers[0] = Values[0];
                                Answers[1] = Values[1];
                                Answers[2] = Values[2];
                                Answers[3] = Values[3];
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nIncorrect split");
                        }
                    }

                    for (int i = 0; i < Sheikh_auto.Count; i++)
                    {
                        Console.WriteLine($"'{Sheikh_auto[i].Name}' '{Sheikh_auto[i].Color}' '{Sheikh_auto[i].Speed}' '{Sheikh_auto[i].Year}'");
                        if
                            ((Answers[0] == Sheikh_auto[i].Name) &&
                             (Answers[1] == Sheikh_auto[i].Color) &&
                             (Int32.Parse(Answers[2]) == Sheikh_auto[i].Speed) &&
                             (Int32.Parse(Answers[3]) == Sheikh_auto[i].Year))
                        {
                            Sheikh_auto.RemoveRange(i, 1);
                            Console.WriteLine("\nSale was succesfull!");
                            break;
                        }
                        else if (i == Sheikh_auto.Count - 1)
                        {
                            Console.WriteLine("You haven't this auto!");
                            Console.WriteLine($"You`re params: '{Answers[0]}' '{Answers[1]}' '{Answers[2]}' '{Answers[3]}'");
                            Console.WriteLine("If you want try again, write 'Yes'");
                            if ("Yes" == Console.ReadLine()) Delete();
                            else Console.WriteLine("\nSale was canceled!");
                        }
                    }

                }
                private bool Compare(string X, string Y)
                {
                    if (X == "") return true;
                    else if (X == Y) return true;
                    else return false;
                }
                private bool Compare(string X, int Y)
                {
                    try
                    {
                        if (X == "") return true;
                        else if (Int32.Parse(X) == Y) return true;
                        else return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }
                private void Drive()
                {
                    Console.WriteLine("\nWhich car do you want to drive?");

                    List();

                    Console.WriteLine("\nWrite params in order and split with ';'");
                    Console.WriteLine("To skip param you can write ';' after another one similar\n");

                    string Line = Console.ReadLine()!;
                    Console.WriteLine();

                    string[] Values = Line.Split(';');
                    if (Values.Length == 4)
                    {
                        int counter = 0;
                        for (int i = 0; i < Sheikh_auto.Count; i++)
                        {
                            if (Compare(Values[0], Sheikh_auto[i].Name) &&
                                Compare(Values[1], Sheikh_auto[i].Color) &&
                                Compare(Values[2], Sheikh_auto[i].Speed) &&
                                Compare(Values[3], Sheikh_auto[i].Year))
                            {
                                if (counter == 0) Console.WriteLine("\nCars found\n");
                                counter++;
                                Console.WriteLine($"| #{counter} | " +
                                    $"{Sheikh_auto[i].Name} | " +
                                    $"{Sheikh_auto[i].Color} | " +
                                    $"{Sheikh_auto[i].Speed} | " +
                                    $"{Sheikh_auto[i].Year} |");
                            }
                        }
                        if (counter == 0)
                        {
                            Console.WriteLine("\nNo cars found\nWrite 'Yes' to try again");
                            if (Console.ReadLine() == "Yes") Drive();
                            else Console.WriteLine("\nYou have returned to your garage!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWrong number of ';'\n\nDo you want try again?\n'Yes' to try again");
                        if (Console.ReadLine() == "Yes") Drive();
                        else Console.WriteLine("\nYou have returned to your garage!");
                    }

                }
                public void Enter()
                {
                    Console.WriteLine("Greetings Mr. Sheikh!");

                    while (true)
                    {
                        Console.WriteLine("\nWhat do you want?\n");
                        Console.WriteLine("-'List' - list of your cars");
                        Console.WriteLine("-'Buy' - add new car");
                        Console.WriteLine("-'Sale' - remove car");
                        Console.WriteLine("-'Drive' - choose your car to drive");
                        Console.WriteLine("-'Exit'\n");

                        string Line = Console.ReadLine()!;

                        if (Line == "List") List();
                        else if (Line == "Buy") Sheikh_auto.Add(new Auto());
                        else if (Line == "Sale") Delete();
                        else if (Line == "Drive") Drive();
                        else if (Line == "Exit") break;
                        else Console.WriteLine("\nI don't understand you.");
                        Console.WriteLine("\n=========================================");
                    }
                }
            }
        }
        //Друге завдання
        public class Telephones
        {
            public class Rotor_telephone
            {
                public int mobile_number;
                public char[] allowed_symbols = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                public bool TakeCall(bool dothat, int mobile_number)
                {
                    if (dothat) return true;
                    else return true;
                }
                public bool MakeCall(bool dothat, int mobile_number)
                {
                    if (dothat) return true;
                    else return true;
                }
            }
            public class Push_button_telephone : Rotor_telephone
            {
                new public char[] allowed_symbols = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '*', '#' };

                public void call_on_display(int numberphone)
                {
                    
                }
            }
            public class Mobilephone_bw_display : Push_button_telephone
            {
                new public List<char> allowed_symbols = new List<char>();
                
                public int display_resolution_x;
                public int display_resolution_y;

                public double display_heigh;
                public double display_width;

                public string device_color;

                public Mobilephone_bw_display()
                {
                    for (int i = char.MinValue; i <= char.MaxValue; i++)
                    {
                        char c = Convert.ToChar(i);
                        if (!char.IsControl(c))
                        {
                            allowed_symbols.Add(c);
                        }
                    }
                }

                public string send_SMS(int mobile_phone)
                {
                    string SMS = "";
                    return SMS;
                }
                public string recive_SMS()
                {
                    string SMS = "";
                    return SMS;
                }
            }
            public class Mobilephone_colorfull : Mobilephone_bw_display
            {
                public long colors;
                public struct SIM
                {
                    public int mobile_number;
                    public string operator_name;
                    public int sim_number;
                };
                public List<SIM> sim_cards = new List<SIM>(2);
                new public bool MakeCall(int target_number)
                {
                    return MakeCall(0,target_number);                    
                }
                public bool MakeCall(int number, int target_number)
                {
                    for(int i = 0; i < sim_cards.Count; i++)
                    {
                        if((number == sim_cards[i].sim_number) & (target_number > 0)) return true;
                    }
                    return false;
                }
                public bool SendMMS(string src_content, int number, out bool result)
                {
                    if (src_content != "" && number > 0) return result = true;
                    return result = false;
                }
                public bool ReciveMMS(out string src_content, string input)
                {
                    if(input != "")
                    {
                        src_content = input;
                        return true;
                    }
                    else
                    {
                        src_content = "";
                        return false;
                    }
                }

            }
            public class Smartphone : Mobilephone_colorfull
            {
                public bool IsSensor;
                public short maxtouch;
                public struct Camera
                {
                    public bool Isfrontal;
                    public short camera_number;
                    public string parametrs;
                }
                List<Camera> cameras = new List<Camera>(2);
                public void MakePhoto(out string src, bool is_photo, bool is_frontal, int camera_number)
                {
                    src = "";
                    if (is_photo)
                    {
                        for (int i = 0; i < cameras.Count; i++)
                        {
                            if (camera_number == cameras[i].camera_number)
                            {
                                if (cameras[i].Isfrontal == is_frontal)
                                {
                                    src = $"*/frontal.png";
                                    break;
                                }
                                else
                                {
                                    src = $"*/backal.png";
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MakeVideo(out src, is_photo,is_frontal,camera_number);    
                    }
                    src = "";
                }
                public void MakeVideo(out string src, bool is_photo, bool is_frontal, int camera_number)
                {
                    src = "";
                    if (!is_photo)
                    {
                        for (int i = 0; i < cameras.Count; i++)
                        {
                            if (camera_number == cameras[i].camera_number)
                            {
                                if (cameras[i].Isfrontal == is_frontal)
                                {
                                    src = $"*/frontal.png";
                                    break;
                                }
                                else
                                {
                                    src = $"*/backal.png";
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MakePhoto(out src, is_photo, is_frontal, camera_number);
                    }

                }
            }

        }
        static void Main(string[] args)
        {

            Sheikh.Garage garage = new Sheikh.Garage();
            garage.Enter();
        }
    }

}