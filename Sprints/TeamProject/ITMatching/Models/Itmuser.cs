using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ITMatching.Models
{
    public partial class Itmuser
    {
        public Itmuser()
        {
            Clients = new HashSet<Client>();
            Experts = new HashSet<Expert>();
        }

        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Username { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Expert> Experts { get; set; }
    }
}
