using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class RequestService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? RequestId { get; set; }
    }
}
