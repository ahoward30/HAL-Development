using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("Service")]
    public partial class Service
    {
        public Service()
        {
            ExpertServices = new HashSet<ExpertService>();
            RequestServices = new HashSet<RequestService>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ServiceCategory { get; set; }
        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        [InverseProperty(nameof(ExpertService.Service))]
        public virtual ICollection<ExpertService> ExpertServices { get; set; }
        [InverseProperty(nameof(RequestService.Service))]
        public virtual ICollection<RequestService> RequestServices { get; set; }
    }
}
