using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string ServiceCategory { get; set; }
        public string ServiceName { get; set; }
    }
}
