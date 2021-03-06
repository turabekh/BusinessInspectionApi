﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Guideline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ICollection<InspectionGuideline> InspectionGuidelines { get; set; }
    }
}
