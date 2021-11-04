using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.Repository
{

    public enum Event { Golf, Bowling, AmusementPark, Concert }

    public class Outing
    {
        public Event EventType { get; set; }
        public int Attendees { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; }
        
        public Outing(Event typeOfEvent, int attendees, DateTime dateOfEvent, decimal costPerPerson)
        {
            EventType = typeOfEvent;
            Attendees = attendees;
            EventDate = dateOfEvent;
            CostPerPerson = costPerPerson;
            TotalCost = costPerPerson * attendees;
        }
    }
}
