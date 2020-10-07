using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bieco
{
    public class ClaimRepository
    {
        protected readonly Queue<InsuranceCl> _claims = new Queue<InsuranceCl>();
        public bool AddClaimToQu(InsuranceCl claim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(claim);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<InsuranceCl> GetAllInsuranceClaims()
        {
            return _claims;
        }
    }
}
