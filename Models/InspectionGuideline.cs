using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InspectionGuideline
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }
        public int GuidlineId { get; set; }
        public virtual Guideline Guideline { get; set; }
        public bool Pass { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
