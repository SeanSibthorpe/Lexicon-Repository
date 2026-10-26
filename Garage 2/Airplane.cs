using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_2
{
    internal class Airplane : Vehicle
    {
        private int NumberOfEngines { get; set; }

        public static int GetEngines()
        {
            bool inputing = true;
            Console.WriteLine("How many engines does it have?\n");
            while (inputing)
            {
                if (!int.TryParse(Console.ReadLine(), out int engines))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (engines < 1 || engines > 10)
                {
                    Console.WriteLine("Amount of engines must be more than 0 and fewer than 11.\n");
                }
                else
                {
                    return engines;
                }
            }

            return 1;
        }

        public Airplane(int engines, string regnr, int wheels, Colour colour) : base(regnr, wheels, colour)
        {
            NumberOfEngines = engines;
        }

        public override string GetVehicleType()
        {
            return "Airplane";
        }
    }
}
