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
    }

    public class Menu
    {
        public List<MenuItem> _menu;

    }
    public class MenuRepository
    {
        Menu _menu = new Menu();
            
        public void AddMenuItem(MenuItem itemToAdd)
        {
            
        }


        public void DeleteMenuItem(MenuItem itemToRemove)
        {

        }

        public void ShowMenuItems()
        {
            foreach(MenuItem item in _menu)
            {

            }
        }

    }
}
