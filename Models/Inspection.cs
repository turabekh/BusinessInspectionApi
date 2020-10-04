using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string CertificateNumber { get; set; }
        public virtual Business Business { get; set; }
        public int AgencyId { get; set; }
        public virtual EnforcementAgency EnforcementAgency { get; set; }
        public int InspectionTypeId { get; set; }
        public virtual InspectionType InspectionType { get; set; }
        public virtual ICollection<InspectionGuideline> InspectionGuidelines { get; set; }

    }
}
