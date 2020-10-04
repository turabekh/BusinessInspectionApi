using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataTransferObjects.Read
{
    public class InspectionGuidelineDto
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string GuidelineName { get; set; }
        public bool Pass { get; set; }

    }
}
