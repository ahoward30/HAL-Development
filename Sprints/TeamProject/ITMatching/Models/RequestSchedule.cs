using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models
{
    public class RequestSchedule
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int RequestId { get; set; }
        public string Day { get; set; }
        public int Hour { get; set; }
    }
}