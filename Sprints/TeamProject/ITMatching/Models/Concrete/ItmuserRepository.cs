using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{
    public class ItmuserRepository : Repository<Itmuser>, IItmuserRepository
    {
        public ItmuserRepository(ITMatchingAppContext ctx) : base(ctx)
        {

        }

        public virtual async Task<Itmuser> GetByAspNetUserIdAsync(string aspNetUserId)
        {
            var itmUser = await _dbSet.AsNoTracking().Where(u => u.AspNetUserId == aspNetUserId).FirstOrDefaultAsync();
            return itmUser;
        }
    }
}
