using Challenge2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ConsoleApp
{
    public class ConsoleUI
    {
        ClaimQueue allClaims = new ClaimQueue();

        public void Run()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            bool keepRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n");
                Console.WriteLine("1. See all claims");
                Console.WriteLine("2. Process next claim");
                Console.WriteLine("3. Enter a new claim");
                Console.WriteLine("4. Exit\n");
                Console.Write("Your selection: ");

                char s = Console.ReadKey().KeyChar;
                switch (s)
                {
                    case '1':
                        ViewClaims();
                        break;
                    case '2':
                        NextClaim();
                        break;
                    case '3':
                        NewClaim();
                        break;
                    case '4':
                        keepRunning = false;
                        break;
                    case '_':
                    default:
                        break;
                }
            }
            while (keepRunning == true);
        }
        public void ViewClaims()
        {
            Console.Clear();

            Console.WriteLine("Claim ID   Type    Description         Amount      Date of Accident   Date of Claim   Is Valid?");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            string row;

            foreach (Claim item in allClaims._claims)
            {
                row = String.Format("{0,-10} {1,-7} {2,-19} ${3,-10} {4,-18} {5,-15} {6,-9}", item.ClaimID, item.TypeOfClaim, item.Description, item.ClaimAmount, item.DateOfAccident.ToShortDateString(), item.DateOfClaim.ToShortDateString(), item.IsValid);
                Console.WriteLine(row);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Push any key to continue.");
            Console.ReadKey();
        }
        
        public void NextClaim()
        {
            bool keepRunning = true;
            char response;
            Console.Clear();
            do
            {
                Claim claimToProcess = allClaims.Peek();
                if (claimToProcess == null)
                {
                    Console.WriteLine("No claims waiting to be processed.");
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Claim ID: " + claimToProcess.ClaimID);
                    Console.WriteLine("Type: " + claimToProcess.TypeOfClaim);
                    Console.WriteLine("Description: " + claimToProcess.Description);
                    Console.WriteLine("Amount: $" + claimToProcess.ClaimAmount);
                    Console.WriteLine("Date of accident: " + claimToProcess.DateOfAccident);
                    Console.WriteLine("Date of claim: " + claimToProcess.DateOfClaim);
                    Console.WriteLine("Claim valid? " + claimToProcess.IsValid);
                    Console.WriteLine("\n");
                    Console.Write("Do you want to process this claim now (Y/N)? ");
                    response = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (response)
                    {
                        case 'Y':
                        case 'y':
                            keepRunning = false;
                            allClaims.Get();
                            if (claimToProcess.IsValid == false)
                            {
                                Console.WriteLine("Claim is not valid. It has been removed from the queue.");
                            }
                            else
                            {
                                Console.WriteLine("Claim processed successfully and removed from queue.");
                            }
                            break;
                        case 'N':
                        case 'n':
                            keepRunning = false;
                            Console.WriteLine("Claim not processed.");
                            break;
                        case '_':
                            keepRunning = true;
                            break;
                    }
                }
            }
            while (keepRunning == true);
            Console.WriteLine("Push any key to continue.");
            Console.ReadKey();
        }

        public void NewClaim()
        {
            bool success = false;
            string userInput;
            int claimID;
            ClaimType typeOfClaim = ClaimType.Car;
            string description;
            decimal claimAmount;
            DateTime dateOfAccident;
            DateTime dateOfClaim;

            Console.Clear();

            do
            {
                Console.Write("Enter the claim ID: ");
                userInput = Console.ReadLine();
                success = int.TryParse(userInput, out claimID);
            }
            while (success == false);

            do
            {
                Console.Write("What type of claim (Car, Home, Theft)? ");
                userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "CAR":
                        typeOfClaim = ClaimType.Car;
                        success = true;
                        break;
                    case "HOME":
                        typeOfClaim = ClaimType.Home;
                        success = true;
                        break;
                    case "THEFT":
                        typeOfClaim = ClaimType.Theft;
                        success = true;
                        break;
                    case "_":
                        success = false;
                        break;
                }
            }
            while (success == false);

            Console.Write("Please enter claim description: ");
            description = Console.ReadLine();

            do
            {
                Console.Write("Enter the claim amount: ");
                userInput = Console.ReadLine();
                success = decimal.TryParse(userInput, out claimAmount);
            }
            while (success == false);

            do
            {
                Console.Write("Enter the date of the accident (MM/DD/YYYY): ");
                userInput = Console.ReadLine();
                success = DateTime.TryParse(userInput, out dateOfAccident);
                if (success == false)
                {
                    Console.WriteLine("Please enter a valid date in MM/DD/YYYY format.");
                }
            }
            while (success == false);

            do
            {
                Console.Write("Enter the date of the claim (MM/DD/YYYY): ");
                userInput = Console.ReadLine();
                success = DateTime.TryParse(userInput, out dateOfClaim);
                if (success == false)
                {
                    Console.WriteLine("Please enter a valid date in MM/DD/YYYY format.");
                }
            }
            while (success == false);

            // ready to build up a claim object and enqueue

            Claim claimToAdd = new Claim(claimID, typeOfClaim, description, claimAmount, dateOfAccident, dateOfClaim);

            allClaims.Add(claimToAdd);
        }
    }
}