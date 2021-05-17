using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Meeting
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ExpertId { get; set; }
        public int HelpRequestId { get; set; }
        public String Status { get; set; }
        public DateTime ClientTimestamp { get; set; }
        public DateTime ExpertTimestamp { get; set; }
        public DateTime MatchExpireTimestamp { get; set; }
        public int? Feedback { get; set; }
    }
}
