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
            newClaim.IsValid = IsValidCheck(newClaim.DateOfIncident, newClaim.DateOfClaim);

            _claims.Enqueue(newClaim);
            return true;
        }

        public bool RemoveFromQueue()
        {
            if (_claims.Count > 0)
            {
                _claims.Dequeue();
                return true;
            }
            return false;
        }

        public Queue<ClaimsModel> ViewAllClaims()
        {
            return _claims;
        }

        public ClaimsModel HandleNextClaim()
        {
            var claim = _claims.Peek();
            return claim;
        }

        public bool IsValidCheck(DateTime accidentDate, DateTime dateToCheck)
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
        private DateTime ClaimsDate() => DateTime.Now;
        private int IdCounter() => ++_idCounter;
    }
}
