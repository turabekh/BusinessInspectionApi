using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataTransferObjects.Read
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public string CertificateNumber { get; set; }
        public string BusinessName { get; set; }
        public string EnforcementAgencyName { get; set; }
        public string InspectionType { get; set; }
        public string County { get; set; }
        public string CountyCode { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public IEnumerable<InspectionGuidelineDto> InspectionGuidelineDtos { get; set; }
    }
}
