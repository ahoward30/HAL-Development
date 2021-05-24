using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public int MeetingId { get; set; }
        [Required]
        public int SentBy { get; set; } // Itmuser.Id of sender
        [Required]
        public DateTime? SentTime { get; set; }
        [Required]
        public string Text { get; set; }
        public string FileURL { get; set; }
        public bool IsAttachment
        {
            get => !string.IsNullOrWhiteSpace(FileURL);
        }
    }
}
