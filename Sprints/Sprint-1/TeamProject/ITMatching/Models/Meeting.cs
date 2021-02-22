using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Meeting
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? ExpertId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Expert Expert { get; set; }
        public virtual Service Service { get; set; }
    }
}
