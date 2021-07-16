using _4_CompanyOutingsPOCO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_CompanyOutingsPOCO.EventTypes
{
    public class Bowling : IEvent
    {
        public string Title { get; set; }
        public int PeopleAttended { get; set; }

        public decimal CostPerPerson => 10m;

        public decimal EventCost => 30m;
    }
}
