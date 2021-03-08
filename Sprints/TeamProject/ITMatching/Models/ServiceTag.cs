using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class ServiceTag
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? ExpertId { get; set; }
    }
}
