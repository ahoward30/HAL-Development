using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Abstract
{
    public interface IItmuserRepository : IRepository<Itmuser>
    {
        Task<Itmuser> GetByAspNetUserIdAsync(string aspNetUserId);
    }
}
