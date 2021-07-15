using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_BadgesPOCO
{
    public class BadgesModel
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();
        public string BadgeName { get; set; }

        public BadgesModel()
        {

        }

        public BadgesModel(List<string> doorNames, string badgeName)
        {            
            DoorNames = doorNames;
            BadgeName = badgeName;
        }
    }
}
