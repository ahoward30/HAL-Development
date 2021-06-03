using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITMatching.Models
{
    [Table("ITMUser")]
    public partial class Itmuser
    {
        public Itmuser()
        {
            Clients = new HashSet<Client>();
            Experts = new HashSet<Expert>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("ASPNetUserID")]
        [StringLength(450)]
        public string AspNetUserId { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(13)]
        public string PhoneNumber { get; set; }

        [InverseProperty(nameof(Client.Itmuser))]
        public virtual ICollection<Client> Clients { get; set; }
        [InverseProperty(nameof(Expert.Itmuser))]
        public virtual ICollection<Expert> Experts { get; set; }
    }
}
