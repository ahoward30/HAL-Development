using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class PotentialMatch
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int ExpertId { get; set; }
        public double MatchingScore { get; set; } 
    }
}
