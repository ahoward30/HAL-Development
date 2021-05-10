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

        public virtual async Task<List<Meeting>> GetMatchingMeetingsByExpertIdAsync(int expertId)
        {
            var meetings = await _dbSet.AsNoTracking().Where(m => m.ExpertId == expertId && m.Status == "Matching").ToListAsync();
            foreach (var meetingId in meetings.Select(m => m.Id))
            {
                var meeting = await this.FindByIdAsync(meetingId);
                meeting.ExpertTimestamp = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return meetings;
        }

        public virtual async Task UpdateStatusAsync(int meetingId, string status)
        {
            var meeting = await this.FindByIdAsync(meetingId);
            if (status.ToLower() == "rejected")
            { meeting.ExpertId = 0; }
            else
            { meeting.Status = status; }
            _context.Update(meeting);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
