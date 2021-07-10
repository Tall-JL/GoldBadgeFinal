using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClaimsPOCO
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class ClaimsModel
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimsModel()
        {

        }
        public ClaimsModel(ClaimType claimType, string description, int claimAmount, DateTime dateOfIncident)
        {
            
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
        }
    }
}
