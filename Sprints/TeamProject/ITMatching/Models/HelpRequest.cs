using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ITMatching.Models
{
    public partial class HelpRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "A help request title is required")]
        public string RequestTitle { get; set; }
        [Required(ErrorMessage = "A help request description is required")]
        public string RequestDescription { get; set; }
        [Required]
        public bool IsOpen { get; set; }
    }
}
