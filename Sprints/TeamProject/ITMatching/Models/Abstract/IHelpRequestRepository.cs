using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Abstract
{
    public interface IHelpRequestRepository : IRepository<HelpRequest>
    {
        Task<List<HelpRequest>> GetListByIdsAsync(List<int> helpRequestIds);
    }
}
