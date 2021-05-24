using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{
    public class HelpRequestRepository : Repository<HelpRequest>, IHelpRequestRepository
    {
        public HelpRequestRepository(ITMatchingAppContext ctx) : base(ctx)
        {

        }

        public virtual async Task<List<HelpRequest>> GetListByIdsAsync(List<int> helpRequestIds)
        {
            var helpRequests = await _dbSet.AsNoTracking().Where(hr => helpRequestIds.Contains(hr.Id)).ToListAsync();
            return helpRequests;
        }
    }
}
