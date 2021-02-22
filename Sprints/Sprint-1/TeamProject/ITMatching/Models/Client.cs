using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Client
    {
        public Client()
        {
            ExpertFeedbacks = new HashSet<ExpertFeedback>();
            Meetings = new HashSet<Meeting>();
        }

        public int Id { get; set; }
        public int? ItmuserId { get; set; }

        public virtual Itmuser Itmuser { get; set; }
        public virtual ICollection<ExpertFeedback> ExpertFeedbacks { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
