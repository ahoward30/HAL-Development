using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class ExpertFeedback
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public int ClientId { get; set; }
        public int MeetingID { get; set; }
        public int Rating { get; set; }
    }
}
