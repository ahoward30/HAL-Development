using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITMatching.Tests
{
    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<IdentityUser>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<IdentityUser>>().Object,
              new IUserValidator<IdentityUser>[0],
              new IPasswordValidator<IdentityUser>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }

        public override Task<IdentityUser> GetUserAsync(ClaimsPrincipal principal)
        {
            return Task.FromResult(new IdentityUser
            {
                Id = "2a44c5fa-13a4-4477-82db-512da5e6f32a",
                Email = "jame@im.com"
            });
        }

        public override Task<bool> HasPasswordAsync(IdentityUser user)
        {
            return Task.FromResult(true);
        }

        public override Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            return Task.FromResult(true);
        }

        public override Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            return Task.FromResult(IdentityResult.Success);
        }

    }
}
