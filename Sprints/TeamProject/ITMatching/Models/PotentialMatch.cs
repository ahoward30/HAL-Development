using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("PotentialMatch")]
    public partial class PotentialMatch
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MeetingID")]
        public int MeetingId { get; set; }
        [Column("ExpertID")]
        public int ExpertId { get; set; }
        public double MatchingScore { get; set; }

        [ForeignKey(nameof(ExpertId))]
        [InverseProperty("PotentialMatches")]
        public virtual Expert Expert { get; set; }
        [ForeignKey(nameof(MeetingId))]
        [InverseProperty("PotentialMatches")]
        public virtual Meeting Meeting { get; set; }
    }
}
