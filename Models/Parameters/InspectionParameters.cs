using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Parameters
{
    public class InspectionParameters : QueryStringParameters
    {
        public string EnforcementAgencyType { get; set; } = string.Empty;
        public string CertificateNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CountyCode { get; set; } = string.Empty;
        public string CountyName { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string DateLastUpdated { get; set; } = string.Empty;


    }
}
