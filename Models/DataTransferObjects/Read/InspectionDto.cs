using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataTransferObjects.Read
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public string BusinessBRCCode { get; set; }
        public string BusinessBusinessName { get; set; }
        public string EnforcementAgencyName { get; set; }
        public string InspectionTypeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public IEnumerable<InspectionGuidelineDto> InspectionGuidelineDtos { get; set; }
    }
}
