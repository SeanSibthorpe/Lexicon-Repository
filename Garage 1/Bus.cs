using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1
{
    internal class Bus : Vehicle
    {
        private int NumberOfSeats { get; set; }

        public static int GetBusSeats()
        {
            bool inputing = true;
            Console.WriteLine("How many seats does it have?\n");
            while (inputing)
            {
                if (!int.TryParse(Console.ReadLine(), out int busSeats))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (busSeats < 8)
                {
                    Console.WriteLine("Number of seats must be 8 or greater.\n");
                }
                else
                {
                    return busSeats;
                }
            }

            return 8;
        }

        public Bus(int seats, string regnr, int wheels, Colour colour) : base(regnr, wheels, colour)
        {
            NumberOfSeats = seats;  
        }

        public override string GetVehicleType()
        {
            return "Bus";
        }
    }
}
