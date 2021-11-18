using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Take_2
{
    public enum ClaimType
    {
        Home = 1,
        Theft,
        Car,
    }
    class Claims
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimType TypeOfClaim { get; set; }

        public Claims(int claimID, ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            TypeOfClaim = type;
        }
        public Claims() { }
    }
}
