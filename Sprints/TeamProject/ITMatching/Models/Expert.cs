using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("Expert")]
    public partial class Expert
    {
        public Expert()
        {
            ExpertFeedbacks = new HashSet<ExpertFeedback>();
            ExpertServices = new HashSet<ExpertService>();
            PotentialMatches = new HashSet<PotentialMatch>();
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ITMUserID")]
        public int ItmuserId { get; set; }
        [StringLength(60)]
        public string WorkSchedule { get; set; }
        public bool IsAvailable { get; set; }

        [ForeignKey(nameof(ItmuserId))]
        [InverseProperty("Experts")]
        public virtual Itmuser Itmuser { get; set; }
        [InverseProperty(nameof(ExpertFeedback.Expert))]
        public virtual ICollection<ExpertFeedback> ExpertFeedbacks { get; set; }
        [InverseProperty(nameof(ExpertService.Expert))]
        public virtual ICollection<ExpertService> ExpertServices { get; set; }
        [InverseProperty(nameof(PotentialMatch.Expert))]
        public virtual ICollection<PotentialMatch> PotentialMatches { get; set; }
        [InverseProperty("Expert")]
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
