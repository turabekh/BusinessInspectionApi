using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Naics { get; set; }
        public string SectorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? Active { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
