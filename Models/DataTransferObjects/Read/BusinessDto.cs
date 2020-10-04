using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataTransferObjects.Read
{
    public class BusinessDto
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string BRCCode { get; set; }
        public string CountyCountyName { get; set; }
        public string SectorSectorName { get; set; }
        public IEnumerable<InspectionDto> Inspections { get; set; }
    }
}
