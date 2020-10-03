using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class County
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }

    }
}
