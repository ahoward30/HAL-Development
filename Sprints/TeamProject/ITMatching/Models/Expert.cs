using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Expert
    {
        public int Id { get; set; }
        public int ItmuserId { get; set; }
        public String WorkSchedule { get; set; }
        public bool IsAvailable { get; set; }
    }
}
