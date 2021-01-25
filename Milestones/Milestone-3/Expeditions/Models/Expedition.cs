using System;
using System.Collections.Generic;

namespace Expeditions.Models
{
    public partial class Expedition
    {
        public int Id { get; set; }
        public string Season { get; set; }
        public int? Year { get; set; }
        public DateTime? StartDate { get; set; }
        public string TerminationReason { get; set; }
        public bool? OxygenUsed { get; set; }
        public int? PeakId { get; set; }
        public int? TrekkingAgencyId { get; set; }

        public virtual Peak Peak { get; set; }
        public virtual TrekkingAgency TrekkingAgency { get; set; }
    }
}
