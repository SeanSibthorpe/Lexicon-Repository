using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1
{
    internal class Boat : Vehicle
    {
        private int Length { get; set; }

        public static int GetLength()
        {
            bool inputing = true;
            Console.WriteLine("What is the length of the boat? (feet)\n");
            while (inputing)
            {
                if (!int.TryParse(Console.ReadLine(), out int length))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (length < 10)
                {
                    Console.WriteLine("Length must be 10 or greater.\n");
                }
                else
                {
                    return length;
                }
            }

            return 10;
        }

        public Boat(int length, string regnr, int wheels, Colour colour) : base (regnr, wheels, colour) { 
            Length = length;
        }

        public override string GetVehicleType()
        {
            return "Boat";
        }
    }
}
