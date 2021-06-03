using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("HelpRequest")]
    public partial class HelpRequest
    {
        public HelpRequest()
        {
            Meetings = new HashSet<Meeting>();
            RequestSchedules = new HashSet<RequestSchedule>();
            RequestServices = new HashSet<RequestService>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Required]
        [StringLength(40)]
        public string RequestTitle { get; set; }
        [Required]
        [StringLength(2000)]
        public string RequestDescription { get; set; }
        public bool IsOpen { get; set; }

        [InverseProperty(nameof(Meeting.HelpRequest))]
        public virtual ICollection<Meeting> Meetings { get; set; }
        [InverseProperty(nameof(RequestSchedule.Request))]
        public virtual ICollection<RequestSchedule> RequestSchedules { get; set; }
        [InverseProperty(nameof(RequestService.Request))]
        public virtual ICollection<RequestService> RequestServices { get; set; }
    }
}
