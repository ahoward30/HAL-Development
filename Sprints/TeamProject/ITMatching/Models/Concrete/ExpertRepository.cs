using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{
    public class ExpertRepository : Repository<Expert>, IExpertRepository
    {
        public ExpertRepository(ITMatchingAppContext ctx) : base(ctx)
        {

        }

        public virtual async Task<Expert> GetByItmUserIdAsync(int itmUserId)
        {
            var itmUser = await _dbSet.AsNoTracking().Where(eu => eu.ItmuserId == itmUserId).FirstOrDefaultAsync();
            return itmUser;
        }

        public virtual async Task SetStatusAsync(int expertId, bool isAvailable)
        {
            var expert = await this.FindByIdAsync(expertId);
            expert.IsAvailable = isAvailable;
            _context.Update(expert);
            await _context.SaveChangesAsync();
            return;
        }

        public virtual async Task ToggleStatusAsync(int expertId)
        {
            var expert = await this.FindByIdAsync(expertId);
            expert.IsAvailable = !expert.IsAvailable;
            _context.Update(expert);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
