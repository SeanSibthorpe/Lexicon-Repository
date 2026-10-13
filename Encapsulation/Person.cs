using System;

namespace Encapsulation
{
    public class Person
    {

        //Variables
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        //Properties
        public string FirstName 
        { get 
            { return firstName; 
            }
            private set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }
        

        public string LastName 
        { get 
            { return lastName; 
            } 
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }
        public int Age 
        { get 
            { return age; 
            } 
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary 
        { get 
            { return salary; 
            }
            private set
            {
                if(value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 dollars!");
                }
                salary = value;
            }
        }

        //Constructors
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;

            /*
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
            */

        }

        //Methods
        public override string ToString()
        {
            //return $"{firstName} {lastName} is {age} years old.";
            
            return $"{firstName} {lastName} receives {salary:F2} dollars.";

        }

        public void IncreaseSalary(decimal percentage)
        {
            percentage = percentage/100;

            if (age < 30)
            {
                salary += salary * (percentage/2);

            }
            else
            {
               salary += salary * percentage;

            }
        }
    
    }
   
}

