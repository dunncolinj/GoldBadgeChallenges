using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.Repository
{
    public class OutingsRepo
    {
        public List<Outing> _outingList = new List<Outing>();
        
        public void AddOuting(Outing outingToAdd)
        {
            _outingList.Add(outingToAdd);
        }

        public decimal GetCombinedCost()
        {
            decimal sum = 0;
            foreach (Outing item in _outingList)
            {
                sum = sum + item.TotalCost;
            }
            return sum;
        }

        public decimal GetCostByType(Event typeOfEvent)
        {
            decimal sum = 0;
            foreach (Outing item in _outingList)
            {
                if (item.EventType == typeOfEvent)
                {
                    sum = sum + item.TotalCost;
                }
            }
            return sum;
        }
    }
}
