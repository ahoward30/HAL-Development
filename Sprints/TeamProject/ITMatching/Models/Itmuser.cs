using System;
using System.Collections.Generic;

#nullable disable

namespace ITMatching.Models
{
    public partial class Itmuser
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
