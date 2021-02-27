using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Expert
    {
        public Expert()
        {
            ExpertFeedbacks = new HashSet<ExpertFeedback>();
            Meetings = new HashSet<Meeting>();
            ServiceTags = new HashSet<ServiceTag>();
        }

        public int Id { get; set; }
        public string WorkSchedule { get; set; }
        public int? ItmuserId { get; set; }

        public virtual Itmuser Itmuser { get; set; }
        public virtual ICollection<ExpertFeedback> ExpertFeedbacks { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<ServiceTag> ServiceTags { get; set; }
    }
}
