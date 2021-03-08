using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Data
{
    /// <summary>
    /// Helper class to hold all the information we need to construct the users for this app. Basically
    /// a union of ITMatching and IdentityUser. Not great to have to duplicate this data but it is only for one-time seeding
    /// of the databases. Does NOT hold passwords since we need to store those in a secret location.
    /// </summary>
    public class UserInfoData
    { 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool EmailConfirmed { get; set; } = true;
    }
    /// <summary>
    /// Data to be used to seed the ITMatchingUsers and ASPNetUsers tables
    /// </summary>
    public class SeedData
    {
        public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
        {
            new UserInfoData { UserName = "AlexH", Email = "alexh@mail.com", FirstName = "Alex", LastName = "Howard" },
            new UserInfoData { UserName = "AdnanA", Email = "adnana@mail.com", FirstName = "Adnan", LastName = "Almarzooq" },
            new UserInfoData { UserName = "JimmyL", Email = "jimmyl@mail.com", FirstName = "Jimmy", LastName = "Larios" },
            new UserInfoData { UserName = "Dylan", Email = "dylans@mail.com", FirstName = "Dylan", LastName = "Stewart" },
            new UserInfoData { UserName = "JuliusC", Email = "juliusc@mail.com", FirstName = "Julius", LastName = "Chen" }
        };
    }
}
