using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Abstract
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        Task<List<Meeting>> GetMatchingMeetingsByExpertIdAsync(int expertId);
        Task UpdateStatusAsync(int meetingId, string status);
    }
}
