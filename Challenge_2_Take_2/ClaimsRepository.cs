using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Take_2
{
    class ClaimsRepository
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        public Queue<Claims> ListOfClaims { get; set; }

        //Create
        public void AddClaimToList(Claims claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        //Peek
        public Claims Peek()
        {
            return
            _queueOfClaims.Peek();

        }
        //Dequeue
        public Claims Dequeue()
        {
            return
            _queueOfClaims.Dequeue();
        }
        //Read
        public Queue<Claims> GetClaims()
        {
            return _queueOfClaims;
        }
        private Claims GetClaimByClaimID(int originalClaimID)
        {
            throw new NotImplementedException();
        }
        //Delete
        public bool RemoveClaimFromList(int claimID)
        {
            Claims claim = GetClaimbyClaimID(claimID);

            if (claim == null)
            {
                return false;
            }

            int initialCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(claim);

            if (initialCount > _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        private Claims GetClaimbyClaimID(int claimID)
        {
            foreach (Claims claim in _queueOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }


    }
}
