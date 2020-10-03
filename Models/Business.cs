using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Occupancy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? WomanOwned { get; set; }
        public bool? MinorityBusiness { get; set; }
        public bool? VeteranOwned { get; set; }
        public bool Verified { get; set; }
        public bool IsConfirmed { get; set; }
        public string Status { get; set; }
        public string BRCCode { get; set; }
        public string LanguageCode { get; set; }
        public int CountyId { get; set; }
        public virtual County County { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }


    }
}
