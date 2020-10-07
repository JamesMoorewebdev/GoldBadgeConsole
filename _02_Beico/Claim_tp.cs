using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bieco
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class InsuranceCl
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan claimSpan = DateOfClaim - DateOfIncident;
                double claimSpanInDays = claimSpan.TotalDays;
                int days = Convert.ToInt32(Math.Floor(claimSpanInDays));

                if (days <= 29.9)
                {
                    return true;
                }
                return false;
            }
        }
        public InsuranceCl()
        {

        }
        public InsuranceCl(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
