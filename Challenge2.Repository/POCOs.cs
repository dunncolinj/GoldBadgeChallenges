using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Repository
{
    public enum ClaimType { Car, Home, Theft }

    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; }

        public Claim(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;

            var diffOfDates = dateOfClaim - dateOfAccident;

            IsValid = (diffOfDates.Days <= 30);
        }
    }


}