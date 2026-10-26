using System;
using System.Collections.Generic;
//using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Garage_1.Vehicle;

namespace Garage_1
{
    internal class Garage
    {
        private Vehicle[] vehicleStorage = new Vehicle[0];
        int maxCapacity;
        int currentCapacity = 0;
        public void ListVehicles()
        {
            Console.WriteLine("Listing all vehicles");
            foreach (Vehicle v in vehicleStorage)
            {
                if (v != null)
                {
                    Console.WriteLine($"{v.GetVehicleType()}: {v.RegNr}, {v.ThisColour}");
                }
            }

            Console.WriteLine("");


        }

        public void ListVehicleTypes()
        {
            //List Vehicle Types and amount of each type
            int cars = 0;
            int motorcycles = 0;
            int busses = 0;
            int boats = 0;
            int airplanes = 0;
            foreach (Vehicle v in vehicleStorage) 
            {
                if (v != null)
                {
                    string type = v.GetVehicleType();
                    switch (type)
                    {
                        case "Car":
                            cars++;
                            break;
                        case "Motorcycle":
                            motorcycles++;
                            break;
                        case "Bus":
                            busses++;
                            break;
                        case "Boat":
                            boats++;
                            break;
                        case "Airplane":
                            airplanes++;
                            break;
                    }
                }
                
            }

            Console.WriteLine("Listing vehicle types and amount stored.");
            Console.WriteLine("Cars: " +  cars);
            Console.WriteLine("Motorcycles: " + motorcycles);
            Console.WriteLine("Busses: " + busses);
            Console.WriteLine("Boats: " + boats);
            Console.WriteLine("Airplanes: " + airplanes + "\n");

        }

        public void ListVehiclesUsingFilter()
        {
            //List all parked vehicles using specified filters.
            //IEnumerable<Vehicle> filteredVehicles = vehicleStorage.Where(v => v != null);
            Vehicle[] filteredVehicles = new Vehicle[vehicleStorage.Length];
            Array.Copy(vehicleStorage, filteredVehicles, vehicleStorage.Length);

            bool filterType = false;
            string selectedType = string.Empty;

            bool filterColour = false;
            Colour colourFilter = Colour.Black;
            
            bool filterWheels = false;
            int wheelAmount = 0;

            Console.WriteLine("Press 1 to filter by vehicle type, press 2 to include all types\n");
            ConsoleKeyInfo key = Console.ReadKey(true);

            

            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
            {

                Console.WriteLine("Choose a Vehicle type:");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Motorcycle");
                Console.WriteLine("3. Bus");
                Console.WriteLine("4. Boat");
                Console.WriteLine("5. Airplane\n");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        selectedType = "Car";
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        selectedType = "Motorcycle";
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        selectedType = "Bus";
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        selectedType = "Boat";
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        selectedType = "Airplane";
                        break;

                    default:
                        Console.WriteLine("Incorrect Input.\n");
                        return;

                }
                filterType = true;                

            }

            Console.WriteLine("Press 1 to filter by colour, press 2 to include all colours\n");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
            {
                Console.WriteLine("Choose a Colour:");
                Console.WriteLine("1. Black");
                Console.WriteLine("2. White");
                Console.WriteLine("3. Red");
                Console.WriteLine("4. Blue");
                Console.WriteLine("5. Green");
                Console.WriteLine("6. Yellow");
                Console.WriteLine("7. Orange");
                Console.WriteLine("8. Purple");
                Console.WriteLine("9. Gray\n");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        colourFilter = Colour.Black;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        colourFilter = Colour.White;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        colourFilter = Colour.Red;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        colourFilter = Colour.Blue;
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        colourFilter = Colour.Green;
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        colourFilter = Colour.Yellow;
                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        colourFilter = Colour.Orange;
                        break;

                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        colourFilter = Colour.Purple;
                        break;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        colourFilter = Colour.Gray;
                        break;

                    default:
                        Console.WriteLine("Incorrect Input.\n");
                        return;
                }
                filterColour = true;

            }

            Console.WriteLine("Press 1 to filter by wheel amount, press 2 to include all wheel amounts\n");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
            {
                Console.Write("Enter a wheel amount: ");
                if (!int.TryParse(Console.ReadLine(), out wheelAmount))
                {
                    Console.WriteLine("Incorrect input.\n");
                    return;
                }
                else if (wheelAmount < 0)
                {
                    Console.WriteLine("Wheel amount must be 0 or greater.\n");
                    return;
                }
                else
                {
                    filterWheels = true;
                }


            }


            if (filterType == true)
            {
                //filteredVehicles = filteredVehicles.Where(v => v.GetVehicleType() == selectedType);
                for (int i = 0; i < filteredVehicles.Length; i++)
                {
                    if (filteredVehicles[i] != null)
                    {
                        if (filteredVehicles[i].GetVehicleType() != selectedType)
                        {
                            filteredVehicles[i] = null;
                        }
                    }
                    
                }
            }

            if (filterColour == true)
            {
                //filteredVehicles = filteredVehicles.Where(v => v.ThisColour == colourFilter);
                for (int i = 0; i < filteredVehicles.Length; i++)
                {
                    if (filteredVehicles[i] != null)
                    {
                        if (filteredVehicles[i].ThisColour != colourFilter)
                        {
                            filteredVehicles[i] = null;
                        }
                    }

                }

            }

            if (filterWheels == true)
            {
                //filteredVehicles = filteredVehicles.Where(v => v.Wheels == wheelAmount);
                for (int i = 0; i < filteredVehicles.Length; i++)
                {
                    if (filteredVehicles[i] != null)
                    {
                        if (filteredVehicles[i].Wheels != wheelAmount)
                        {
                            filteredVehicles[i] = null;
                        }
                    }

                }
            }

            bool isEmpty = true;
            foreach (Vehicle vehicle in filteredVehicles)
            {
                if (vehicle == null)
                {
                    continue;
                }
                isEmpty = false;
                Console.WriteLine($"{vehicle.GetVehicleType()}: {vehicle.RegNr}, {vehicle.ThisColour}");
            }

            if (isEmpty)
            {
                Console.WriteLine("There were no vehicles with those specifications.");
            }
            Console.WriteLine("");
        }

        private int FindEmptySpot()
        {
            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }

        public void CreateCar()
        {

            string regNr = EnterRegNr();
            int wheels = SelectWheels();
            Vehicle.Colour colour = SelectColour();
            Console.WriteLine($"{colour.ToString()} chosen.\n");
            Car.FuelType fuel = Car.SelectFuelType();

            int index = FindEmptySpot();

            if (index < 0)
            {
                //No spot was found
                Console.WriteLine("No spot availble");
                return;
            }
            else
            {
                vehicleStorage[index] = new Car(fuel, regNr, wheels, colour);
                currentCapacity++;
                Console.WriteLine("Vehicle successfully added\n");
            }         

        }
        public void CreateBus()
        {

            string regNr = EnterRegNr();
            int wheels = SelectWheels();
            Vehicle.Colour colour = SelectColour();
            Console.WriteLine($"{colour.ToString()} chosen.\n");
            int busSeats = Bus.GetBusSeats();

            int index = FindEmptySpot();

            if (index < 0)
            {
                //No spot was found
                Console.WriteLine("No spot availble");
                return;
            }
            else
            {
                vehicleStorage[index] = new Bus(busSeats, regNr, wheels, colour);
                currentCapacity++;
                Console.WriteLine("Vehicle successfully added\n");
            }

        }
        public void CreateBoat()
        {

            string regNr = EnterRegNr();
            int wheels = SelectWheels();
            Vehicle.Colour colour = SelectColour();
            Console.WriteLine($"{colour.ToString()} chosen.\n");
            int length = Boat.GetLength();

            int index = FindEmptySpot();

            if (index < 0)
            {
                //No spot was found
                Console.WriteLine("No spot availble");
                return;
            }
            else
            {
                vehicleStorage[index] = new Boat(length, regNr, wheels, colour);
                currentCapacity++;
                Console.WriteLine("Vehicle successfully added\n");
            }

        }
        public void CreateMotorcycle()
        {

            string regNr = EnterRegNr();
            int wheels = SelectWheels();
            Vehicle.Colour colour = SelectColour();
            Console.WriteLine($"{colour.ToString()} chosen.\n");
            int cylinderVolume = Motorcycle.GetCylinderVolume();

            int index = FindEmptySpot();

            if (index < 0)
            {
                //No spot was found
                Console.WriteLine("No spot availble");
                return;
            }
            else
            {
                vehicleStorage[index] = new Motorcycle(cylinderVolume, regNr, wheels, colour);
                currentCapacity++;
                Console.WriteLine("Vehicle successfully added\n");
            }

        }
        public void CreateAirplane()
        {

            string regNr = EnterRegNr();
            int wheels = SelectWheels();
            Vehicle.Colour colour = SelectColour();
            Console.WriteLine($"{colour.ToString()} chosen.\n");
            int engines = Airplane.GetEngines();

            int index = FindEmptySpot();

            if (index < 0)
            {
                //No spot was found
                Console.WriteLine("No spot availble");
                return;
            }
            else
            {
                vehicleStorage[index] = new Airplane(engines, regNr, wheels, colour);
                currentCapacity++;
                Console.WriteLine("Vehicle successfully added\n");
            }

        }        
        public void AddVehicle()
        {
            if (GarageIsFull())
            {
                //There is no space
                Console.WriteLine("The garage is full. Returning to Main Menu.\n");
                return;
            }

            bool addingVehicle = true;
            while (addingVehicle)
            {
                Console.WriteLine("Press 1 to add a Car.\nPress 2 to add a Motorcycle.\nPress 3 to add a Bus.\nPress 4 to add a Boat.\nPress 5 to add an Airplane\nPress 0 to return to Main Menu.");
                ConsoleKeyInfo key = Console.ReadKey(true);             


                switch (key.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        addingVehicle = false;
                        Console.WriteLine ("Returning to Main Menu.\n");
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //Add car
                        CreateCar();
                        addingVehicle = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //Add MC
                        CreateMotorcycle();
                        addingVehicle = false;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Add bus
                        CreateBus();
                        addingVehicle = false;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //Add boat
                        CreateBoat();
                        addingVehicle = false;
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //add plane
                        CreateAirplane();
                        addingVehicle = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect Input.\n");
                        break;
                }

            }


        }

        public void RemoveVehicle()
        {
            Console.Write("Enter the registrationnumber: ");
            string regNr = (Console.ReadLine() ?? "").ToUpper();
            Console.WriteLine("");
            if (regNr.Length != 6)
            {
                Console.WriteLine("Incorrect registrationnumber. The format must be ABC123 or ABC12D.\n");
                return;
            }

            if (!validateRegNr(regNr))
            {
                Console.WriteLine("Incorrect registrationnumber. The format must be ABC123 or ABC12D.\n");
            }      
            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] != null)
                {
                    if (vehicleStorage[i].RegNr == regNr.ToUpper())
                    {
                        vehicleStorage[i] = null; ;
                        currentCapacity--;
                        Console.WriteLine("Vehicle successfully removed.\n");
                        return;
                    }
                }
            }
            Console.WriteLine("Vehicle was not found.\n");
        }

        public void RetrieveVehicleByRegNr()
        {
            Console.Write("Enter the regestrationnumber: ");
            string regNr = (Console.ReadLine() ?? "").ToUpper();
            Console.WriteLine("");

            if (regNr.Length != 6)
            {
                Console.WriteLine("Incorrect registrationnumber. Must be a combination of 6 letters and numbers.\n");
                return;
            }
            foreach (char c in regNr)
            {
                if (!((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                {
                    Console.WriteLine("Registration number must contain only letters and numbers.\n");
                    return; ;
                }
            }
            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] != null)
                {
                    if (vehicleStorage[i].RegNr == regNr.ToUpper())
                    {
                        Colour colour = vehicleStorage[i].ThisColour;
                        string type = vehicleStorage[i].GetVehicleType();


                        Console.WriteLine($"Vehicle information.\nRegistrationnumber: {regNr.ToUpper()}\nVehicle Type: {type}\nColour: {colour}");
                        return;
                    }
                }
            }
            Console.WriteLine("Vehicle was not found.\n");
        }

        private Vehicle.Colour SelectColour()
        {

            while (true)
            {
                Console.WriteLine("Choose a Colour:");
                Console.WriteLine("1. Black");
                Console.WriteLine("2. White");
                Console.WriteLine("3. Red");
                Console.WriteLine("4. Blue");
                Console.WriteLine("5. Green");
                Console.WriteLine("6. Yellow");
                Console.WriteLine("7. Orange");
                Console.WriteLine("8. Purple");
                Console.WriteLine("9. Gray\n");

                ConsoleKeyInfo colourKey = Console.ReadKey(true);


                switch (colourKey.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return Vehicle.Colour.Black;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return Vehicle.Colour.White;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return Vehicle.Colour.Red;


                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return Vehicle.Colour.Blue;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        return Vehicle.Colour.Green;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        return Vehicle.Colour.Yellow;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        return Vehicle.Colour.Orange;

                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        return Vehicle.Colour.Purple;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        return Vehicle.Colour.Gray;

                    default:
                        Console.WriteLine("Incorrect Input.\n");
                        break;
                }

            }

            
        }

        private int SelectWheels()
        {
            Console.WriteLine("How many wheels does it have?");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int wheels))
                {
                    Console.WriteLine("\nPlease enter a valid number.\n");
                }
                else if (wheels < 0)
                {
                    Console.WriteLine("\nAmount of wheels must be 0 or greater.\n");
                }
                else
                {
                    return wheels;
                }
            }
            
        }

        private bool GarageIsFull()
        {
            if (currentCapacity >= maxCapacity)
            {
                return true;
            }

            else 
            { 
                return false; 
            }

        }

        
        private string EnterRegNr()
        {
            bool entering = true;
            string regNr = null;
            while (entering)
            {
                Console.WriteLine("What is the registrationnumber?\n");
                regNr = (Console.ReadLine() ?? "").ToUpper();
                /*
                if (vehicleStorage.Any(v => v != null && v.RegNr == regNr))
                {
                    Console.WriteLine ("A vehicle with that registrationnumber already exists.\n");
                    continue;

                }
                */

                bool duplicateRegNr = false;
                foreach(Vehicle v in vehicleStorage)
                {
                    if (v == null) continue;
                    if (v.RegNr == regNr)
                    {
                        duplicateRegNr = true;
                        break;
                    }
                }

                if (duplicateRegNr) {
                    Console.WriteLine("A vehicle with that registrationnumber already exists. Please enter a different registrationnumber.\n");
                    continue;
                }
                if (regNr.Length != 6)
                {
                    Console.WriteLine("Incorrect registrationnumber. The format must be ABC123 or ABC12D.\n");
                    continue;
                }

                if (validateRegNr(regNr))
                {
                    entering = false;
                }
                else
                {
                    Console.WriteLine("Registration number must contain only letters and numbers.\n");
                    continue;
                }

            }

            return regNr;

        }

        public bool Populate() //Requires 10 empty spots
        {
            int counter = 0;
            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] == null)
                {
                    counter++;
                }
            }
            if (counter >= 10) //10 empty spots exist
            {
                vehicleStorage[FindEmptySpot()] = new Car(Car.FuelType.Gasoline, "123456", 4, Colour.Red);
                vehicleStorage[FindEmptySpot()] = new Motorcycle(200, "321123", 2, Colour.Red);
                vehicleStorage[FindEmptySpot()] = new Boat(40, "ABC456", 0, Colour.Blue);
                vehicleStorage[FindEmptySpot()] = new Bus(40, "A1B2C3", 8, Colour.Red);
                vehicleStorage[FindEmptySpot()] = new Airplane(6, "AIR888", 2, Colour.White);
                vehicleStorage[FindEmptySpot()] = new Car(Car.FuelType.Diesel, "321321", 4, Colour.Black);
                vehicleStorage[FindEmptySpot()] = new Car(Car.FuelType.Diesel, "D33S3L", 4, Colour.Purple);
                vehicleStorage[FindEmptySpot()] = new Motorcycle(600, "890JKL", 3, Colour.Green);
                vehicleStorage[FindEmptySpot()] = new Boat(25, "DSA903", 0, Colour.Orange);
                vehicleStorage[FindEmptySpot()] = new Car(Car.FuelType.Gasoline, "890ASD", 4, Colour.Green);

                currentCapacity += 10;
                return true;
            }
            else
            {
                Console.WriteLine("Not enough space. Requires ten empty spots.\n");
                return false;
            }
            

        }

        private bool validateRegNr(string regnr)
        {
            return ((char.IsLetter(regnr[0]) && 
                char.IsLetter(regnr[1]) && 
                char.IsLetter(regnr[2]) && 
                char.IsDigit(regnr[3]) && 
                char.IsDigit(regnr[4]) && 
                char.IsDigit(regnr[5])) 
                || 
                (char.IsLetter(regnr[0]) && 
                char.IsLetter(regnr[1]) && 
                char.IsLetter(regnr[2]) && 
                char.IsDigit(regnr[3]) && 
                char.IsDigit(regnr[4]) && 
                char.IsLetter(regnr[5])));
        }
       
        
        public Garage(int size)
        {
            vehicleStorage = new Vehicle[size];
            maxCapacity = size;
        }


    }

    
}
