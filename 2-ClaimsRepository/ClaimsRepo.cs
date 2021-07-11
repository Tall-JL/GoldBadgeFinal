using _2_ClaimsPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClaimsRepository
{
    public class ClaimsRepo
    {
        public Queue<ClaimsModel> _claims = new Queue<ClaimsModel>();
        private int _idCounter = default;



        public bool AddToQueue(ClaimsModel newClaim)
        {
            newClaim.ClaimID = IdCounter();
            newClaim.DateOfClaim = ClaimsDate();
            newClaim.IsValid = IsValidCheck(newClaim.DateOfIncident, newClaim.DateOfClaim );

            _claims.Enqueue(newClaim);
            return true;
        }


        public Queue<ClaimsModel> ViewAllClaims()
        {
            return _claims;
        }

        //public Queue<ClaimsModel> HandleNextClaim()
        //{
        //    //ClaimsModel claimsToPeek = new ClaimsModel();
        //    //Queue<ClaimsModel> claimsToPeek = new Queue<ClaimsModel>();
            
        //    Console.WriteLine();
        //    return true;
           
            
        //}
        

        private int IdCounter() => ++_idCounter;
        private DateTime ClaimsDate() => DateTime.Now;
        private bool IsValidCheck(DateTime accidentDate, DateTime dateToCheck)
        {
            ClaimsModel newClaim = new ClaimsModel();
            if (dateToCheck >= accidentDate && dateToCheck < accidentDate.AddDays(30))
            {
                return newClaim.IsValid = true;
                
            }
            else
            {
                return newClaim.IsValid = false;
                
            }
        }
    }
}
