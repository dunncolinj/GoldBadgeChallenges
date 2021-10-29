using Challenge3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.ConsoleApp
{
    public class ConsoleUI
    {
        BadgeDict _badges = new BadgeDict();

        public void Run()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            char userInput;
            bool keepRunning = true;

            do
            {
                Console.WriteLine("Main Menu\n");
                Console.WriteLine("1. Add a badge");
                Console.WriteLine("2. Edit badge door assignments");
                Console.WriteLine("3. List all badges and access");
                Console.WriteLine("4. Exit");

                Console.Write("Selection: ");
                userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        AddBadge();
                        break;
                    case '2':
                        EditBadge();
                        break;
                    case '3':
                        ListBadges();
                        break;
                    case '4':
                        keepRunning = false;
                        break;
                    case '_':
                        keepRunning = true;
                        break;
                }
            }
            while (keepRunning == true);
        }

        public void AddBadge()
        {
            Console.Clear();

            bool success = false;
            string userInput;
            int id;
            List<string> doors = new List<string>();

            do
            {
                Console.Write("Please enter the badge number: ");
                userInput = Console.ReadLine();
                success = int.TryParse(userInput, out id);
                if (_badges.CheckID(id) == true)
                {
                    success = false;
                    Console.WriteLine("Please enter a badge number not already in use.");
                }
            }
            while (success == false);

            success = false;
            do
            {
                Console.Write("Enter a door badge " + id + " needs to access (. to finish): ");
                userInput = Console.ReadLine();
                if (userInput[0] == '.')
                {
                    success = true;
                }
                else
                {
                    doors.Add(userInput);
                }
            }
            while (success == false);

            Badge myBadge = new Badge(id, doors);
            success = _badges.Add(myBadge);
            if (success == true)
            {
                Console.WriteLine("Badge added successfully.");
            }
            else
            {
                Console.WriteLine("Badge was not added.");
            }
        }

        public void EditBadge()
        {
            char userInput;
            bool keepRunning = true;
            int badgeNumber;

            do
            {
                Console.Clear();
                Console.WriteLine("Edit a badge\n");
                Console.WriteLine("1. Add a door to a badge");
                Console.WriteLine("2. Remove a door from a badge");
                Console.WriteLine("3. Exit to main menu");
                Console.Write("Selection: ");
                userInput = Console.ReadKey().KeyChar;
                switch (userInput)
                {
                    case '1':
                        badgeNumber = getBadge();
                        AddDoor(badgeNumber);
                        break;
                    case '2':
                        badgeNumber = getBadge();
                        RemoveDoor(badgeNumber);
                        break;
                    case '3':
                        keepRunning = false;
                        break;
                    case '_':
                        keepRunning = true;
                        break;
                }
            }
            while (keepRunning == true);
        }
        
        public int getBadge()
        {
            bool success = false;
            string userInput;
            int id;

            do
            {
                Console.Write("Enter the badge number: ");
                userInput = Console.ReadLine();
                success = int.TryParse(userInput, out id);
            }
            while (success == false);
            return id;
        }
        public void RemoveDoor(int id)
        {
            string userInput;
            List<string> newDoors = new List<string>();

            if (_badges.CheckID(id) == false)
            {
                Console.WriteLine("Badge ID " + id + " does not exist.");
            }
            else
            {
                Badge badgeToUpdate = _badges.Get(id);
                newDoors = badgeToUpdate.DoorNames;

                Console.Write("Enter door to remove: ");
                userInput = Console.ReadLine();
                if (newDoors.Contains(userInput))
                {
                    newDoors.Remove(userInput);
                    _badges.UpdateDoors(id, newDoors);
                }
                else
                {
                    Console.WriteLine("User did not have access to door " + userInput + ". No action taken.");
                }
                Console.Write("Badge " + id + "has access to doors: ");
                foreach (string door in newDoors)
                {
                    Console.Write(door + " ");
                }
                Console.WriteLine();
            }
        }

        public void AddDoor(int id)
        {
            string userInput;
            List<string> newDoors = new List<string>();

            if (_badges.CheckID(id) == false)
            {
                Console.WriteLine("Badge ID " + id + " does not exist.");
            }
            else
            {
                Badge badgeToUpdate = _badges.Get(id);
                newDoors = badgeToUpdate.DoorNames;

                Console.Write("Enter door to add: ");
                userInput = Console.ReadLine();
                newDoors.Add(userInput);
                _badges.UpdateDoors(id, newDoors);

                Console.Write("Badge " + id + "has access to doors: ");
                foreach (string door in newDoors)
                {
                    Console.Write(door + " ");
                }
                Console.WriteLine();
            }
        }

        public void ListBadges()
        {
            var _badgeCopy = _badges.Read();
            
            if (_badgeCopy.Count == 0)
            {
                Console.WriteLine("No badge information to display.");
            }
            else
            {
                Console.WriteLine("Badge #\tDoor Access");
                Console.WriteLine("-------\t-----------");

                foreach (KeyValuePair<int, Badge> kvp in _badgeCopy)
                {
                    Console.Write(kvp.Key + "\t");
                    foreach (string door in kvp.Value.DoorNames)
                    {
                        Console.Write(door + " ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Push a key to continue.");
            Console.ReadKey();
        }
    }
}