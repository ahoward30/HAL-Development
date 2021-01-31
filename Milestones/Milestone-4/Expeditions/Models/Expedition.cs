using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Expeditions.Models
{
    public partial class Expedition
    {
        public int Id { get; set; }
        public string Season { get; set; }
        public int? Year { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Termination Reason")]
        public string TerminationReason { get; set; }
        [Display(Name = "Oxygen Used")]
        public bool? OxygenUsed { get; set; }
        public int? PeakId { get; set; }
        public int? TrekkingAgencyId { get; set; }

        public virtual Peak Peak { get; set; }
        [Display(Name = "Trekking Agency")]

        public virtual TrekkingAgency TrekkingAgency { get; set; }
    }
}
