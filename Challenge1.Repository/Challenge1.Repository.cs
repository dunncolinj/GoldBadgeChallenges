using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }

    public class Menu
    {
        public List<MenuItem> _menu = new List<MenuItem>();
           
            
        public void Add(MenuItem itemToAdd)
        {
            _menu.Add(itemToAdd);
        }


        public void Remove(MenuItem itemToRemove)
        {
            _menu.Remove(itemToRemove);
        }

        public void Show()
        {
            Console.WriteLine("Menu\n\n");
            foreach(MenuItem item in _menu)
            {
                Console.WriteLine(item.MealNumber + ". " + item.MealName);
                Console.WriteLine(item.Description);
                Console.Write("Ingredients: ");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.Write(ingredient + ", ");
                }
                Console.WriteLine();
                Console.WriteLine("Price: " + item.Price);
            }
        }

    }
}
