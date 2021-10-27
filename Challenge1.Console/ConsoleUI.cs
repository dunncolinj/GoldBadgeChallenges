using Challenge1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.ConsoleApp
{
    public class ConsoleUI
    {
        // init variables
        Menu _mymenu = new Menu();

        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool stillRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Café Menu Options");
                Console.WriteLine();
                Console.WriteLine("1. Add menu item");
                Console.WriteLine("2. Remove menu item");
                Console.WriteLine("3. View menu");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose action: ");
                char s = Console.ReadKey().KeyChar;
                switch (s)
                {
                    case '1':
                        AddMenuItem();
                        break;
                    case '2':
                        RemoveMenuItem();
                        break;
                    case '3':
                        ViewMenu();
                        break;
                    case '4':
                        stillRunning = false;
                        break;
                    case '_':
                        break;
                }
            }
            while (stillRunning == true);
        }

        private void AddMenuItem()
        {
            string userInput;
            int mealNumber;
            string mealName;
            string mealDescription;
            List<string> mealIngredients;
            decimal mealPrice;

            bool success = false;

            Console.Clear();
            do
            {
                Console.Write("Enter meal number: ");
                userInput = Console.ReadLine();
                success = Int32.TryParse(userInput, out mealNumber);
            }
            while (success == false);

            Console.Write("Enter meal name: ");
            userInput = Console.ReadLine();
            mealName = userInput;

            Console.Write("Enter meal description: ");
            userInput = Console.ReadLine();
            mealDescription = userInput;

            mealIngredients = new List<string>();
            do
            {
                Console.Write("Enter ingredients, one per line; enter . to finish.\n");
                userInput = Console.ReadLine();
                if (userInput != ".") mealIngredients.Add(userInput);
            }
            while (userInput != ".");

            success = false;
            do
            {
                Console.Write("Enter price: ");
                userInput = Console.ReadLine();
                success = decimal.TryParse(userInput, out mealPrice);
            }
            while (success == false);

            MenuItem newItem = new MenuItem(mealNumber, mealName, mealDescription, mealIngredients, mealPrice);
            _mymenu.Add(newItem);
        }


        private void RemoveMenuItem()
        {
            string userInput;
            int mealNumber;
            bool success = false;
            MenuItem itemToRemove;

            Console.Clear();
            do
            {
                Console.Write("Enter meal number to remove: ");
                userInput = Console.ReadLine();
                success = Int32.TryParse(userInput, out mealNumber);
            }
            while (success == false);

            itemToRemove = _mymenu.Get(mealNumber);

            if (itemToRemove != null)
            {
                _mymenu.Remove(itemToRemove);
            }
        }

        private void ViewMenu()
        {
            Console.Clear();

            Console.WriteLine("Menu");
            Console.WriteLine("----\n\n");
            foreach (MenuItem item in _mymenu._menu)
            {
                Console.WriteLine(item.MealNumber + ". " + item.MealName);
                Console.WriteLine(item.Description);
                Console.Write("Ingredients: ");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.Write(ingredient + ", ");
                }
                Console.Write("\b ");
                Console.WriteLine();
                Console.WriteLine("Price: " + item.Price + "\n");
            }
            Console.WriteLine("Push a key to continue.");
            Console.ReadKey();
        }
    }
}
