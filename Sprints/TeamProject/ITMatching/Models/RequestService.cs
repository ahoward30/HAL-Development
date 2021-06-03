using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("RequestService")]
    public partial class RequestService
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(HelpRequest.RequestServices))]
        public virtual HelpRequest Request { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("RequestServices")]
        public virtual Service Service { get; set; }
    }
}
