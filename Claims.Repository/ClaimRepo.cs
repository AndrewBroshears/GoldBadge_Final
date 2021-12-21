using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repository
{
    class ClaimRepo
    {
        //Use Queue for first in first out function
        private readonly Queue<Claim> _claimRepo = new Queue<Claim>();
        //Method for creating a claim. Similar to list?
        public void AddClaim(Claim claimToAdd)
        {
            _claimRepo.Enqueue(claimToAdd);
        }
        //Readable Queue of claims.
        public Queue<Claim> GetClaims()
        {
            return _claimRepo;
        }
        //Look at next claim use Peek()
        public Claim NextClaim()
        {
            return _claimRepo.Peek();
        }
        //Delete a claim using Dequeue
        public void RemoveClaim(Claim claimToRemove)
        {
            _claimRepo.Dequeue(claimToRemove);
            return true;
        }
    }
}
