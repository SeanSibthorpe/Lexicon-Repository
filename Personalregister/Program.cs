using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personalregister
{
    internal class Program
    {

        private List<Person> register = new List<Person>();
        private bool running = true;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartUp();

            while (program.running == true)
            {
                Console.WriteLine("");
                program.StartUp();
            }
        }

        private void StartUp()
        {
            Console.WriteLine("Enter 1 to add a person to the register.");
            Console.WriteLine("Enter 2 to print the register.");
            Console.WriteLine("Enter 3 to exit.");


            int input;
            bool correctInput = int.TryParse(Console.ReadLine(), out input);

            if (correctInput == false || (input != 1 && input != 2 && input != 3))
            {
                Console.WriteLine("You entered the wrong input");
                return;

            }

            if (input == 1)
            {
                AddPerson();
            }
            else if (input == 2)
            {
                PrintRegister();
            }
            else if (input == 3) {
                running = false;
            }
            


        }

        private void AddPerson()
        {
            Console.WriteLine("Enter the persons name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the persons wage");
            int wage;
            bool correctInput = int.TryParse(Console.ReadLine(), out wage);

            if (correctInput == false)
            {
                Console.WriteLine("You entered an incorrect wage. The person was not added");
                return;
            }

            Person person = new Person(name, wage);

            register.Add(person);
            Console.WriteLine("");
        }

        private void PrintRegister()
        {
            if (register.Count == 0)
            {
                Console.WriteLine("The register is empty");
                return;
            }

            int i = 1;

            foreach (Person person in register) {
                Console.WriteLine("Person " + i + ". Name: " + person.GetName() + " || Wage: " + person.GetWage());
                i++;
            }
            Console.WriteLine("");

        }
    }

    internal class Person
    {
        private readonly string name;
        private readonly int wage;

        public Person(string name, int wage)
        {
            this.name = name;
            this.wage = wage;
        }

        public string GetName()
        {
            return name;
        }

        public int GetWage()
        {
            return wage;
        }

    }
}
