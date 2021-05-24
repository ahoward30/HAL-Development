using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class ExpertService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? ExpertId { get; set; }
    }
}
