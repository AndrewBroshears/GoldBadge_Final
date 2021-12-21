using Claim.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Repository
{
    public class ClaimRepo
    {
        //Use Queue for first in first out function
        private readonly Queue<ClaimPOCO> _claimRepo = new Queue<ClaimPOCO>();
        //Method for creating a claim. Similar to list?
        public bool AddClaim(ClaimPOCO claimToAdd)
        {//have to check if count added to queue
            if(claimToAdd != null)
            {
                int claimRepo = _claimRepo.Count;
                _claimRepo.Enqueue(claimToAdd);
                int claimRepoAdded = _claimRepo.Count;
                if(claimRepo == claimRepoAdded - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        //Readable Queue of claims.
        public Queue<ClaimPOCO> GetClaims()
        {
            return _claimRepo;
        }
        //Look at next claim use Peek()
        public ClaimPOCO NextClaim()
        {
                return _claimRepo.Peek();
        }
        //Delete a claim using Dequeue
        public bool RemoveClaim()//need to change void to bool and return all paths for Test Check
        {
            if(_claimRepo.Count > 0)
            {
                _claimRepo.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsClaimValid(DateTime incidentDate, DateTime claimDate)
        {
            return claimDate < incidentDate.AddDays(30);
        }
    }
}
