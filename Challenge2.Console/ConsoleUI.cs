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
                Console.WriteLine("2. Take care of next claim");
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

            foreach (Claim item in allClaims._claims)
            {
                Console.WriteLine("{0,10} {1,7} {2,20} ${3,11} {4,18} {5,15} {6,5}", item.ClaimID, item.TypeOfClaim, item.Description, item.ClaimAmount, item.DateOfAccident, item.DateOfClaim, item.IsValid);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Push any key to continue.");
            Console.ReadKey();
        }

        public void NextClaim()
        {
            bool keepRunning = true;
            Console.Clear();
            do
            {
                Claim claimToProcess = allClaims._claims.Peek();
                Console.WriteLine("Claim ID: " + claimToProcess.ClaimID);
                Console.WriteLine("Type: " + claimToProcess.TypeOfClaim);
                Console.WriteLine("Description: " + claimToProcess.Description);
                Console.WriteLine("Amount: $" + claimToProcess.ClaimAmount);
                Console.WriteLine("Date of accident: " + claimToProcess.DateOfAccident);
                Console.WriteLine("Date of claim: " + claimToProcess.DateOfClaim);
                Console.WriteLine("Claim valid? " + claimToProcess.IsValid);
                Console.WriteLine("\n");
                Console.Write("Do you want to deal with this claim now (Y/N)? ");


            }
            while (keepRunning = true);
        }

        public void NewClaim()
        {

        }
    }



}