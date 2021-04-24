using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(ITMatchingAppContext ctx) : base(ctx)
        {

        }

        public virtual async Task<List<Meeting>> GetOpenMeetingsByExpertIdAsync(int expertId) =>
           await _dbSet.AsNoTracking().Where(m => m.ExpertId == expertId && m.Status == "open").ToListAsync();

        public virtual async Task UpdateStatusAsync(int meetingId, string status)
        {
            var meeting = await this.FindByIdAsync(meetingId);
            meeting.Status = status;
            _context.Update(meeting);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
