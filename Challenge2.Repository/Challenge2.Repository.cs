using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Repository
{
    public class ClaimQueue
    {
    public Queue<Claim> _claims = new Queue<Claim>();

        public Claim Get()
        {
            Claim result;
            if (_claims.Count > 0)
            {
                result = _claims.Dequeue();
            }
            else
            {
                result = null;
            }

            return result;
        }

        public void Add(Claim newClaim)
        {
            _claims.Enqueue(newClaim);
        }
    }
}
