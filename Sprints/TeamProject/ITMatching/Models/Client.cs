using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            ExpertFeedbacks = new HashSet<ExpertFeedback>();
            RequestSchedules = new HashSet<RequestSchedule>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ITMUserID")]
        public int ItmuserId { get; set; }

        [ForeignKey(nameof(ItmuserId))]
        [InverseProperty("Clients")]
        public virtual Itmuser Itmuser { get; set; }
        [InverseProperty(nameof(ExpertFeedback.Client))]
        public virtual ICollection<ExpertFeedback> ExpertFeedbacks { get; set; }
        [InverseProperty(nameof(RequestSchedule.Client))]
        public virtual ICollection<RequestSchedule> RequestSchedules { get; set; }
    }
}
