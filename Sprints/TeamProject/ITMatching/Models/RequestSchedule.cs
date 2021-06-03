using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("RequestSchedule")]
    public partial class RequestSchedule
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RequestId { get; set; }
        [StringLength(20)]
        public string Day { get; set; }
        public int? Hour { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("RequestSchedules")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(HelpRequest.RequestSchedules))]
        public virtual HelpRequest Request { get; set; }
    }
}
