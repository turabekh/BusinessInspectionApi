using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataTransferObjects.Read
{
    public class SectorDto
    {
        public int SectorId { get; set; }
        public string Naics { get; set; }
        public string SectorName { get; set; }
    }
}
