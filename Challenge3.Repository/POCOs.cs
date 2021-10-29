using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repository
{
    public class Badge
    {
        public int ID { get; set; }
        public List<string> DoorNames { get; set; }

        public Badge(int id, List<string> doorNames)
        { 
            ID = id;
            DoorNames = doorNames;
        }
    }  
}
