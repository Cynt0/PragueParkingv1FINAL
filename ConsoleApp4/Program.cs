using System;
using System.Linq;

namespace PragueParkingv1 
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] parking = new string[101];
            Array.Fill(parking, "LEDIGT");
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(parking);
            }
            Console.ReadKey(true);
        }
        public static bool MainMenu(string[] parking)
        {

            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine("Hi! And Welcome to Prague parking assistance!");
                Console.WriteLine("How can i be of service?");
                Console.WriteLine("1) Park a vehicle");
                Console.WriteLine("2) Relocate vehicles");
                Console.WriteLine("3) Search for a vehicle by registration number");
                Console.WriteLine("Q) Quit");
                Console.WriteLine("5) Print the array");
                Console.WriteLine("Make a selection:");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        {
                            ParkVehicle(parking);
                            return true;
                        }
                    case "2":
                        {
                            RelocateVehicle(parking);
                            return true;
                        }
                    case "3":
                        {
                            SearchVehicle(parking);
                            return true;
                        }
                    case "q":
                        {
                            Console.WriteLine("Thanks for using Prague parking assistance");
                            Console.WriteLine("Have a nice day!");
                            Environment.Exit(0);
                            return false;
                        }
                    case "5":
                        {
                            PrintArray(parking);
                            return true;
                        }
                    default:
                        {
                            Console.WriteLine("Error: Invalid Input");
                            return true;
                        }
                }
            }
        }

        public static void SearchVehicle(string[] parking)
        {
            Console.WriteLine("Car or MC");
            switch (Console.ReadLine().ToUpper())
            {
                case "CAR":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "CAR" + "_" + Console.ReadLine().ToUpper() + "%";
                        for (int i = 1; i < parking.Length - 1; i++)
                        {
                            if (hit == parking[i])
                            {
                                Console.WriteLine("{0} is located at {1}", hit, i);
                            }
                        }
                        Console.ReadKey();
                        return;
                    }
                case "MC":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "MC" + "_" + Console.ReadLine().ToUpper();
                        for (int i = 100; i > 1; i--)
                        {
                            if (hit == parking[i])
                            {
                                continue;
                            }
                            if (parking[i].Contains('#'))
                            {
                                Console.WriteLine("{0} is located at {1}", hit, i);
                                break;
                            }

                        }
                        Console.ReadKey();
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid Input!");
                        return;
                    }


            }

        }

        public static void RelocateVehicle(string[] parking)
        {
            Console.WriteLine("Car or MC");
            switch (Console.ReadLine().ToUpper())
            {
                case "CAR":
                    {
                        Console.WriteLine("Type in the registration number: ");
                        string hit = "CAR" + "_" + Console.ReadLine().ToUpper() + "%";
                        for (int i = 1; i < parking.Length - 1; i++)
                        {

                            if (hit == parking[i])
                            {
                                Console.WriteLine("{0} is located at {1}", hit, i);
                                Console.WriteLine("Do you wish to relocate? (y/n)");
                                string answer = Console.ReadLine().ToUpper();
                                string yes = "Y";
                                string no = "N";
                                if (answer == yes)
                                {
                                    Console.WriteLine("Enter a parkingspot: (1-100)");
                                    string relocate = Console.ReadLine();
                                    int index = int.Parse(relocate);
                                    var buffer = parking[i];
                                    parking[i] = parking[index];
                                    parking[index] = buffer;
                                    Console.WriteLine("Car: {0}, Successfully moved to spot : {1}", hit, index);
                                    Console.ReadKey();
                                    MainMenu(parking);
                                }
                                        while (answer == no)
                                        {
                                            break;
                                        }
                            }   

                        }
                        break;
                    }
                case "MC":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "MC" + "_" + Console.ReadLine().ToUpper();
                        
                        for (int i = 100; i < parking.Length ; i--)
                        {
                            if (parking[i].Contains(hit + '#'))
                            {
                                hit = hit + '#';
                            }
                            if (parking[i].Contains(hit + '%'))
                            {
                                hit = hit + '%';
                                
                            }

                               if (parking[i].Contains(hit))
                               {
                                   Console.WriteLine("{0} is located at {1}", hit, i);
                                   Console.WriteLine("Do you wish to relocate? (y/n)");
                                        string answer = Console.ReadLine().ToUpper();
                                        string yes = "Y";
                                        string no = "N";
                                        if (answer == yes)
                                        {
                                            Console.WriteLine("Enter a Parkingspot: (1-100)");
                                            string relocate = Console.ReadLine();
                                            int index = int.Parse(relocate);
                                        if (parking[index].Contains('%'))
                                        {
                                            Console.WriteLine("Upptagen. Välj någon annan");
                                            Console.ReadKey();
                                            break;
                                        }
                                        if (hit.Contains('%'))
                                        {
                                            var IndexRemover = hit.IndexOf('%', 0);
                                            parking[i] = parking[i].Remove(IndexRemover);
                                            parking[i] = parking[i] + '#';
                                        }
                                        else if (hit.Contains('#'))
                                        {
                                            parking[i] = parking[i].Remove(0, hit.Length);
                                            parking[i] = parking[i].Replace('%', '#');
                                        }
                                        if (parking[index].Contains("LEDIGT"))
                                        {
                                            parking[index] = String.Empty;
                                            hit = hit.Replace('%', '#');
                                            parking[index] = hit;
                                        }
                                        else if (parking[index].Contains('#'))
                                        {
                                            Console.WriteLine("Vill du parkera din MC bredvid {0}? (y/n)", parking[index]);
                                            answer = Console.ReadLine().ToUpper();
                                      
                                        if (answer == yes)
                                        {
                                            hit = hit.Replace('#', '%');
                                            parking[index] += string.Join('#', hit);
                                            parking[i] = "LEDIGT";
                                        }
                                        while (answer == no)
                                        {
                                            Console.WriteLine("Too bad.");
                                            break;
                                        }

                                        }
                                            Console.WriteLine("MC: {0}, Successfully moved to spot : {1}", hit, index);
                                            Console.ReadKey();
                                        }
                                            break;    
                               }
                                   
                            
                        }
                        break;
                    }
                    

            }
            MainMenu(parking);
        }
        public static void ParkVehicle(string[] parking)
        {
            string car = "car".ToUpper();
            string mc = "mc".ToUpper();
            Console.WriteLine("What type of vehicle do you want to park?");
            switch (Console.ReadLine().ToLower())
            {
                case "car":
                    {
                        ParkingCar(car, parking);
                        DoneParking(parking);
                        break;
                    }
                case "mc":
                    {
                        ParkingMC(mc, parking);
                        DoneParking(parking);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public static void ParkingCar(string car, string[] parking)
        {
            string regNumberCar;
            for (int i = 1; i < 2; i++)
            {
                Console.WriteLine("Skriv in ditt regnr:");
                regNumberCar = car + "_" + Console.ReadLine().ToUpper() + "%";
                if (!parking[i].Contains("LEDIGT"))
                {
                    i++;
                }
                parking[i] = regNumberCar;
            }

        }
        public static void ParkingMC(string mc, string[] parking)
        {
            string regNumberMc;
            Console.WriteLine("Skriv in ditt regnr: ");
            regNumberMc = mc + "_" + Console.ReadLine().ToUpper();
            for (int i = 100; i > 1; i--)
            {

                if (parking[i].Contains('%'))
                {
                    continue;
                }
                if (parking[i].Contains('#'))
                {
                    parking[i] += regNumberMc + '%';
                    break;
                }
                if (parking[i].Contains("LEDIGT"))
                {
                    parking[i] = regNumberMc + '#';
                    break;
                }

            }

        }
        private static void CompareLengthOnString(int length, int compare)
        {
            if (length > compare)
            {
                Console.WriteLine("YAAA BLYAT IDIOT TOO MANY CHARACTERS!(max 10 chars)");
            }
        }

        public static void DoneParking(string[] parking)
        {
            Console.WriteLine("Har du Parkerat klart?(y/n)");
            string answer = Console.ReadLine().ToLower();
            string yes1 = "y";
            string no1 = "n";
            if (answer == yes1)
            {
                MainMenu(parking);
            }
            while (answer == no1)
            {
                ParkVehicle(parking);
                break;
            }
        }
        public static void PrintArray(string[] parking)
        {
            Console.Clear();
            for (int j = 1; j < parking.Length; j++)
            {
              
                if (parking[j].Contains("LEDIGT"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Plats: {0}", j);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" {0}", parking[j]);
                    Console.ResetColor();
                }
                if (!parking[j].Contains("LEDIGT"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Plats: {0}", j);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0}", parking[j]);
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press any Key to Continue..."); Console.ReadKey();
        }
    }
}