using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repository
{


    public class Menu
    {
        public List<MenuItem> _menu = new List<MenuItem>();
           
            
        public bool Add(MenuItem itemToAdd)
        {
            MenuItem result;
            result = Get(itemToAdd.MealNumber);

            if (result == null)
            {
                _menu.Add(itemToAdd);
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool Remove(MenuItem menuItem)
        {
            if (_menu.Contains(menuItem))
            {
                _menu.Remove(menuItem);
                return true;
            }
            else
            {
                return false;
            }                
        }

        public MenuItem Get(int mealNumber)
        {
            MenuItem result = null;

            foreach (MenuItem item in _menu)
            {
                if (item.MealNumber == mealNumber)
                {
                    result = item;
                }
            }
            return result;
        }
    }
}
