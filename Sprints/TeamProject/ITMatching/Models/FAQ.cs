using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("FAQ")]
    public partial class Faq
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Question { get; set; }
        [Required]
        [StringLength(500)]
        public string Answer { get; set; }
    }
}
