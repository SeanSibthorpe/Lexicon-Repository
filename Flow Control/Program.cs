using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    internal class Program
    {
        private bool running = true; //Set = false för att avsluta programmet
        static void Main(string[] args)
        {

            Program program = new Program();
            Console.WriteLine("Welcome to the main menu.");
            Console.WriteLine("");

            while (program.running)
            {
                program.StartMenu();
            }                   

        }

        private void StartMenu()
        {
            Console.WriteLine("Navigate the menu by entering one of the following inputs:");
            Console.WriteLine($"Enter 0 to exit the program. {Environment.NewLine}Enter 1 to Buy a ticket. {Environment.NewLine}Enter 2 to buy tickets for multiple people. {Environment.NewLine}Enter 3 to print a text ten times on repeat. {Environment.NewLine}Enter 4 to enter a text and print the third word.");

            int input = CheckIntInput();

            switch (input)
            {
                case 0:
                    Console.WriteLine("Exiting program");
                    Exit();
                    break;
                case 1:
                    PurchaseSingleTicket();
                    break;
                case 2:
                    PurchaseMultipleTickets();
                    break;
                case 3:
                    RepeatTenTimes();
                    break;
                case 4:
                    PrintTheThirdWord();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;

            }
        }
        private int CheckIntInput()
        {
            int i;

            while (!int.TryParse(Console.ReadLine(), out i) || i < 0)
            {
                Console.WriteLine("Incorrect input. Please enter a number.");

            }

            return i;
        }

        private void PrintTheThirdWord()
        {
            Console.WriteLine("Enter a text consisting of at least three words.");

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (input.Length < 3)
            {
                Console.WriteLine("You entered less than three words. Enter a new text consisting of at least three words.");
                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("The third word is '" + input[2] + "'.");            

        }

        private void RepeatTenTimes()
        {
            Console.WriteLine("Enter a text you wish to 10 times.");
            string input = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Console.Write((i + 1) + ". " + input + ".");
                }
                else
                {
                    Console.Write((i + 1) + ". " + input + ", ");
                }
            }
            Console.WriteLine("");
        }

        private void PurchaseSingleTicket ()
        {
            Console.WriteLine("People below the age of 20 or above the age of 64 are given a discount. Please enter your age.");
            int age = CheckIntInput();
            string output;

            if (age == 0 || age >= 100)
            {
                output = "Price for babies and people over 100: Free admission";
            }

            else if (age > 0 && age < 20)
            {
                output = "Youth price: 80sek.";
            }

            else if (age >= 64)
            {
                output = "Pensioner price: 90sek.";

            }

            else
            {
                output = "Standard price: 120sek";
            }
            
            Console.WriteLine(output);

        }

        private void PurchaseMultipleTickets()
        {
            Console.WriteLine("How many people do you wish to buy tickets for?");
            int amountOfPeople = CheckIntInput();
            if (amountOfPeople <= 0)
            {
                Console.WriteLine("You must enter at least 1 person. Returning to main menu.");
                return;
            }

            int[] ages = new int[amountOfPeople];

            for (int i = 1; i <= amountOfPeople; i++)
            {
                Console.WriteLine("What is the age of person " +  i + "?");
                int age = CheckIntInput();

                ages[i - 1] = age;
            }

            int sum = 0;
            foreach (int age in ages)
            {
               sum += CalculateCost (age);
            }

            Console.WriteLine("The total cost for " + amountOfPeople + " people is " + sum + " sek.");

        }

 
        private int CalculateCost(int age)
        {
            if (age == 0 || age >= 100)
            {
                return 0;
            }

            else if (age > 0 && age < 20)
            {
                return 80;
            }

            else if (age >= 64)
            {
                return 90;
            }

            else
            {
                return 120;
            }
        }

        private void Exit()
        {
            running = false;
        }
    }

}
