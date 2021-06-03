using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("ExpertService")]
    public partial class ExpertService
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? ExpertId { get; set; }

        [ForeignKey(nameof(ExpertId))]
        [InverseProperty("ExpertServices")]
        public virtual Expert Expert { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("ExpertServices")]
        public virtual Service Service { get; set; }
    }
}
