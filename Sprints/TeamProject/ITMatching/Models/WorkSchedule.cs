using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("WorkSchedule")]
    public partial class WorkSchedule
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ExpertId { get; set; }
        [StringLength(20)]
        public string Day { get; set; }
        public int? Hour { get; set; }

        [ForeignKey(nameof(ExpertId))]
        [InverseProperty("WorkSchedules")]
        public virtual Expert Expert { get; set; }
    }
}
