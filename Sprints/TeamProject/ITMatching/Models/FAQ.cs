using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
