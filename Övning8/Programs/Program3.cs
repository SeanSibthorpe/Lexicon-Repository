using Övning8.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Övning8.Programs
{
    internal class Program3 : IThirdInterface, IFourthInterface
    {
        void IThirdInterface.Run()
        {
            Console.WriteLine("Running the third Interface\n");
        }

        int IFourthInterface.Run()
        {
            Console.WriteLine("Running the fourth Interface.\n");
            return 7;
        }
    }
}
