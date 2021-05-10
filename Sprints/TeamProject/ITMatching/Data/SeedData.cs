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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; } = true;
    }
    /// <summary>
    /// Data to be used to seed the ITMatchingUsers and ASPNetUsers tables
    /// </summary>
    public class SeedData
    {
        public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
        {
            new UserInfoData { FirstName = "Alex", LastName = "Howard", Email = "alexh@mail.com", UserName = "AlexH", PhoneNumber = "0123456789" },
            new UserInfoData { FirstName = "Adnan", LastName = "Almarzooq", Email = "adnana@mail.com", UserName = "AdnanA", PhoneNumber = "0123456789" },
            new UserInfoData { FirstName = "Jimmy", LastName = "Larios", Email = "jimmyl@mail.com", UserName = "JimmyL", PhoneNumber = "0123456789" }
        };
    }
}
