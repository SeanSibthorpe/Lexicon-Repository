using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1
{
    internal class Program
    {

        private bool running = true;
        Garage garage = null;

        static void Main(string[] args)
        {
            Program program = new Program();
            while (program.running)
            {
                program.StartMenu();
            }
        }

        private void StartMenu()
        {

            Console.WriteLine("MAIN MENU\nPress 0 to Exit application.\nPress 1 to create a new garage.\nPress 2 to manage existing garage.\n");

            

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
               
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    if (garage != null)
                    {
                        Console.WriteLine("A garage already exists.\n");
                    }
                    else
                    {
                        CreateGarage();
                    }
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if(garage == null)
                    {
                        Console.WriteLine("You have not created a garage.\n");
                    }
                    else
                    {
                        ManageGarage();
                    }
                    break;

                default:
                    Console.WriteLine("Incorrect Input.\n");
                    break;

            }
        }

        private void CreateGarage()
        {

            bool creatingGarage = true;
            while (creatingGarage) {
                //Create a Garage with a user specified size
                Console.Write("Enter garage size: ");

                if (!int.TryParse(Console.ReadLine(), out int size))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (size <= 0)
                {
                    Console.WriteLine("\nGarage size must be greater than zero.\n");
                }
                else
                {
                    garage = new Garage(size);
                    Console.WriteLine($"\nA new garage with {size} spots was created.\n");
                    creatingGarage = false;
                }
            }
                     
        }

        private void ManageGarage()
        {
            Console.WriteLine("GARAGE MENU");
            Console.WriteLine("Press 0 to return to main menu.");
            Console.WriteLine("Press 1 to add a new vehicle.");
            Console.WriteLine("Press 2 to remove a vehicle.");
            Console.WriteLine("Press 3 to find a vehicle by their registration number.");
            Console.WriteLine("Press 4 to list all currently stored vehicles.");
            Console.WriteLine("Press 5 to list all currently stored vehicles using filters.");
            Console.WriteLine("Press 6 to list all vehicle types, and the amount stored of each type.");
            Console.WriteLine("Press 7 to populate with 10 pre-made vehicles.\n");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    //Do nothing and return to main menu
                    break;

                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:

                    garage.AddVehicle();
                    
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    garage.RemoveVehicle();
                    
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    garage.RetrieveVehicleByRegNr();

                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    
                    garage.ListVehicles();

                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:

                    garage.ListVehiclesUsingFilter();

                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:

                    garage.ListVehicleTypes();

                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:

                    garage.Populate();
                    Console.WriteLine("Garage populated.");

                    break;


                default:
                    Console.WriteLine("Incorrect Input.\n");
                    break;

            }

        }

        private void Exit()
        {
            //Exit application
            running = false;
        }


    }
}
