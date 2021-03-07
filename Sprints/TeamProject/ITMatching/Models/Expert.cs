using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Expert
    {
        public int Id { get; set; }
        public int ItmuserId { get; set; }
        public string WorkSchedule { get; set; }
    }
}
