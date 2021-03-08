using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Meeting
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ExpertId { get; set; }
        public int HelpRequestId { get; set; }
    }
}
