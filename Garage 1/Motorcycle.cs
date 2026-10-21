using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1
{
    internal class Motorcycle : Vehicle
    {
        private int CylinderVolume {get; set;}

        public static int GetCylinderVolume()
        {
            bool selecting = true;
            Console.WriteLine("What is the cylinder volume?\n");
            while (selecting)
            {
                if (!int.TryParse(Console.ReadLine(), out int cylinderVolume))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (cylinderVolume < 0)
                {
                    Console.WriteLine("Cylinder Volume must be greater than 0.\n");
                }
                else
                {
                    return cylinderVolume;
                }
            }

            return 1;
        }

        public Motorcycle(int volume, string regnr, int wheels, Colour coulour) : base(regnr, wheels, coulour)
        {
            CylinderVolume = volume;
        }

        public override string GetVehicleType()
        {
            return "Motorcycle";
        }
    }
}
