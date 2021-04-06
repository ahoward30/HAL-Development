using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class HelpRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
        public int ServiceTagId { get; set; }
        public bool IsOpen { get; set; }
    }
}
