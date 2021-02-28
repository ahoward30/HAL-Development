using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Service
    {
        public Service()
        {
            Meetings = new HashSet<Meeting>();
            ServiceTags = new HashSet<ServiceTag>();
        }

        public int Id { get; set; }
        public int ServiceCategory { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<ServiceTag> ServiceTags { get; set; }
    }
}
