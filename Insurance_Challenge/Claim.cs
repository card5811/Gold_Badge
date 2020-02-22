using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Challenge
{
    public enum ClaimType { Auto = 1, Home = 2, Renters = 3, Property = 4 }
    public class Claim
    {

        public Claim() { }
        public int ID { get; set; }
        public string Description { get; set; }
        public double Ammount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateClaimMade { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan dayslapsed = DateClaimMade - DateOfIncident;
                double totalDays = dayslapsed.TotalDays;

                if (totalDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Claim(int id, ClaimType type, string description, double cashAmnt, DateTime incidentDate, DateTime claimDate)
        {
            ID = id;
            TypeOfClaim = type;
            Description = description;
            Ammount = cashAmnt;
            DateOfIncident = incidentDate;
            DateClaimMade = claimDate;
        }
    }
}



