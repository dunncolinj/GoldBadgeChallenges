using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repository
{
    public class BadgeDict
    {
        private Dictionary<int, Badge> _myDict = new Dictionary<int, Badge>();

        public bool Add(Badge badgeToAdd)
        {
            bool result;

            result = CheckID(badgeToAdd.ID);

            if (result == false)
            {
                _myDict.Add(badgeToAdd.ID, badgeToAdd);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoors(int id, List<string> newDoors)
        {
            bool result;

            result = CheckID(id);
            if (result == true)
            { 
                _myDict[id].DoorNames = newDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Badge Get(int id)
        {
            bool result;
            result = CheckID(id);
            if (result == true)
            {
                return _myDict[id];
            }
            else
            {
                return null;
            }
        }
        public bool DeleteAllDoors(Badge badgeToUpdate)
        {
            bool result;

            result = CheckID(badgeToUpdate.ID);
            if (result == true)
            {
                _myDict[badgeToUpdate.ID].DoorNames = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CheckID(int ID)
        {
            return (_myDict.ContainsKey(ID));
        }

        public Dictionary<int, Badge> Read()
        {
            return _myDict;
        }
    }
}
