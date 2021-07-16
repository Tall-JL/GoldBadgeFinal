using _4_CompanyOutingsPOCO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_CompanyOutingsPOCO.EventTypes
{
    public class Golf : IEvent
    {
        public string Title { get; set; }
        public int PeopleAttended { get; set; }

        public decimal CostPerPerson => 15m;

        public decimal EventCost => 40m;
    }
}
