using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_2
{
    internal abstract class Vehicle
    {
        public string RegNr { get;  private set; }
        public int Wheels { get;  private set; }

        public Colour ThisColour { get; private set; }

        public enum Colour
        {
            Black,
            White,
            Red,
            Blue,
            Green,
            Yellow,
            Orange,
            Purple,
            Gray

        }

        public Vehicle(string regNr, int wheels, Colour colour)
        {
            RegNr = regNr.ToUpper();
            Wheels = wheels;
            ThisColour = colour;
        }

        public virtual string GetVehicleType()
        {
            return "Vehicle";
        }
    }
}
