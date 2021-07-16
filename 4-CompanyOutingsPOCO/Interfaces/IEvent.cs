using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_CompanyOutingsPOCO.Interfaces
{
    public interface IEvent
    {
        string Title { get; set; }
        int PeopleAttended { get; set; }
        decimal CostPerPerson { get; }
        decimal EventCost { get; }

    }
}
