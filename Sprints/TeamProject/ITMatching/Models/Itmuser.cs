using System;
using System.Collections.Generic;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Expert> Experts { get; set; }
    }
}
