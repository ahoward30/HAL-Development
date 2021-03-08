using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class WorkSchedule
    {
        public int Id { get; set; }
        public int? ExpertId { get; set; }
        public string Day { get; set; }
        public int? Hour { get; set; }
    }
}
