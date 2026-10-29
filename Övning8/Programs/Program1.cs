using Övning8.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Övning8.Programs
{
    internal class Program1 : IProgramInterface, ISecondInterface
    {
        /*
          public void Run()
          {
            Console.WriteLine("Nu kör vi program 1");

          }
        */

        public void Start()
        {
            Console.WriteLine("Nu kör vi program 1\n");
        }

        public void DoSomething()
        {
            Console.WriteLine("Doing something\n");
        }
    }
}
