using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("ExpertFeedback")]
    public partial class ExpertFeedback
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ExpertID")]
        public int ExpertId { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("MeetingID")]
        public int MeetingId { get; set; }
        public int Rating { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ExpertFeedbacks")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ExpertId))]
        [InverseProperty("ExpertFeedbacks")]
        public virtual Expert Expert { get; set; }
    }
}
