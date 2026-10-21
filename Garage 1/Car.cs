using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1
{
    internal class Car : Vehicle
    {

        public enum FuelType
        {
            Gasoline,
            Diesel
        }

        public FuelType Fuel { get; set; }
        

        public Car (FuelType fueltype, string regnr, int wheels, Colour colour) : base(regnr, wheels, colour) {
            Fuel = fueltype;

        }

        public static FuelType SelectFuelType()
        {
            bool selecting = true;
            while (selecting)
            {
                Console.WriteLine("Press 1 for gasoline engine. Press 2 for Diesel.\n");
                ConsoleKeyInfo fuelkey = Console.ReadKey(true);
                switch (fuelkey.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Gasoline chosen.\n");
                        return FuelType.Gasoline;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Diesel chosen.\n");

                        return FuelType.Diesel;

                    default:
                        Console.WriteLine("Incorrect input.\n");
                        break;

                }

            }
            return FuelType.Gasoline;

        }

        public override string GetVehicleType()
        {
            return "Car";
        }
    }
}
