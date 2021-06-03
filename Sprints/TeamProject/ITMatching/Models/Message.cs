using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("Message")]
    public partial class Message
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MeetingID")]
        public int MeetingId { get; set; }
        public int SentBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SentTime { get; set; }
        [StringLength(2000)]
        public string Text { get; set; }
        [Column("FileUrl")]
        [StringLength(500)]
        public string FileUrl { get; set; }
        public bool IsAttachment
        {
            get => !string.IsNullOrWhiteSpace(FileUrl);
        }

        [ForeignKey(nameof(MeetingId))]
        [InverseProperty("Messages")]
        public virtual Meeting Meeting { get; set; }
    }
}
