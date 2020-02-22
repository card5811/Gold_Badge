using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Challenge
{// Create a ClaimRepository class that has proper methods.
    public class Insurance_Repo
    {
        protected readonly Queue<Claim> _queue = new Queue<Claim>();

        public bool EnquingClaimToQueue(Claim content)
        {
            int claimLength = _queue.Count();
            _queue.Enqueue(content);
            bool wasAdded = claimLength + 1 == _queue.Count();
            return wasAdded;
        }

        public Queue<Claim> GetAllClaims()
        {
            return _queue;
        }

        /*   public Claim GetClaimsByID(int id) for version 2.0
           {
               foreach (Claim content in _queue)
               {
                   if (content.ID == id)
                   {
                       return content;
                   }
               }
               return null;
           } */

        public bool DequeueClaimFromQueue()
        {
            int claimLength = _queue.Count();
            _queue.Dequeue();
            bool wasRemoved = claimLength - 1 == _queue.Count();
            return wasRemoved;
        }
    }
}

