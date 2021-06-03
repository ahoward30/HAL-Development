using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("Meeting")]
    public partial class Meeting
    {
        public Meeting()
        {
            Messages = new HashSet<Message>();
            PotentialMatches = new HashSet<PotentialMatch>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("ExpertID")]
        public int ExpertId { get; set; }
        [Column("HelpRequestID")]
        public int HelpRequestId { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ClientTimestamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpertTimestamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MatchExpireTimestamp { get; set; }
        public int? Feedback { get; set; }
        [Column("numOfPotentialMatches")]
        public int NumOfPotentialMatches { get; set; }

        [ForeignKey(nameof(HelpRequestId))]
        [InverseProperty("Meetings")]
        public virtual HelpRequest HelpRequest { get; set; }
        [InverseProperty(nameof(Message.Meeting))]
        public virtual ICollection<Message> Messages { get; set; }
        [InverseProperty(nameof(PotentialMatch.Meeting))]
        public virtual ICollection<PotentialMatch> PotentialMatches { get; set; }
    }
}
