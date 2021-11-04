using Challenge4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.ConsoleApp
{
    class ConsoleUI
    {
        public OutingsRepo _outings = new Repository.OutingsRepo();

        public void Run()
        {
            MainMenu();

        }

        public void MainMenu()
        {
            bool keepRunning = true;
            char userInput;

            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n");
                Console.WriteLine("1. Add an outing");
                Console.WriteLine("2. Display a list of all outings");
                Console.WriteLine("3. Display the cost of all outings");
                Console.WriteLine("4. Display the cost of outings by type");
                Console.WriteLine("5. Exit application");
                Console.WriteLine("Your selection: ");
                userInput = Console.ReadKey().KeyChar;
                switch (userInput)
                {
                    case '1':
                        Console.Clear();
                        AddOuting();
                        break;
                    case '2':
                        Console.Clear();
                        DisplayAllOutings();
                        break;
                    case '3':
                        Console.Clear();
                        DisplayAllOutingsCost();
                        break;
                    case '4':
                        Console.Clear();
                        DisplayOutingsCostByType();
                        break;
                    case '5':
                        keepRunning = false;
                        break;
                }
            }
            while (keepRunning == true);
        }

        public bool AddOuting()
        {
            char userInput1;
            string userInput2;
            bool inputValid;
            Event typeOfEvent = Event.Golf; // this gets overwritten
            int numOfAttendees;
            DateTime dateOfEvent;
            decimal costPerPerson;

            Console.Clear();
            inputValid = false;

            do
            {
                Console.Write("Choose event type - (G)olf, (B)owling, (A)musement Park, (C)oncert: ");
                userInput1 = Console.ReadKey().KeyChar;
                switch (userInput1)
                {
                    case 'G':
                    case 'g':
                        typeOfEvent = Event.Golf;
                        inputValid = true;
                        break;
                    case 'B':
                    case 'b':
                        typeOfEvent = Event.Bowling;
                        inputValid = true;
                        break;
                    case 'A':
                    case 'a':
                        typeOfEvent = Event.AmusementPark;
                        inputValid = true;
                        break;
                    case 'C':
                    case 'c':
                        typeOfEvent = Event.Concert;
                        inputValid = true;
                        break;
                    case '_':
                        break;
                }
            }
            while (inputValid == false);
            
            Console.WriteLine();

            do
            {
                Console.Write("Enter the number of people who attended: ");
                userInput2 = Console.ReadLine();
                inputValid = Int32.TryParse(userInput2, out numOfAttendees);
            }
            while (inputValid == false);

            do
            {
                Console.Write("Enter the date of the outing: ");
                userInput2 = Console.ReadLine();
                inputValid = DateTime.TryParse(userInput2, out dateOfEvent);
            }
            while (inputValid == false);

            do
            {
                Console.Write("Enter the cost per person: ");
                userInput2 = Console.ReadLine();
                inputValid = Decimal.TryParse(userInput2, out costPerPerson);
            }
            while (inputValid == false);

            Outing outingToAdd = new Outing(typeOfEvent, numOfAttendees, dateOfEvent, costPerPerson);
            _outings.AddOuting(outingToAdd);
            return true;
        }

        public void DisplayAllOutings()
        {
            string lineItem;

            Console.WriteLine("Event Type    | Attendees | Event Date | Cost per Person | Total Cost");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (Outing item in _outings._outingList)
            {
                lineItem = String.Format("{0,-13} | {1,-9} | {2,-10} | ${3,-14} | ${4,-9}", item.EventType, item.Attendees, item.EventDate.ToShortDateString(), item.CostPerPerson, item.TotalCost);
                Console.WriteLine(lineItem);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Push a key to continue.");
            Console.ReadKey();
        }

        public void DisplayAllOutingsCost()
        {
            decimal sum;
            sum = _outings.GetCombinedCost();
            Console.Clear();
            Console.WriteLine("The combined cost of all outings is: $" + sum);
            Console.WriteLine("Push a key to continue.");
            Console.ReadKey();
        }

        public void DisplayOutingsCostByType()
        {
            decimal sum;
            bool inputValid = false;
            Event typeOfEvent = Event.Golf; // this gets overwritten if needed
            char userInput1;

            do
            {
                Console.Write("Choose event type - (G)olf, (B)owling, (A)musement Park, (C)oncert: ");
                userInput1 = Console.ReadKey().KeyChar;
                switch (userInput1)
                {
                    case 'G':
                    case 'g':
                        typeOfEvent = Event.Golf;
                        inputValid = true;
                        break;
                    case 'B':
                    case 'b':
                        typeOfEvent = Event.Bowling;
                        inputValid = true;
                        break;
                    case 'A':
                    case 'a':
                        typeOfEvent = Event.AmusementPark;
                        inputValid = true;
                        break;
                    case 'C':
                    case 'c':
                        typeOfEvent = Event.Concert;
                        inputValid = true;
                        break;
                    case '_':
                        break;
                }
            }
            while (inputValid == false);

            Console.WriteLine();
            sum = _outings.GetCostByType(typeOfEvent);
            Console.WriteLine("The total cost for " + typeOfEvent + " outings is: $" + sum);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    } 
}
