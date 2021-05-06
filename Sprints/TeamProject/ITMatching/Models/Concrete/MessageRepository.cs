using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ITMatchingAppContext ctx) : base(ctx) { }

        public virtual async Task<List<Message>> GetMessagesByMeetingIdAsync(int meetingId) =>
            await _dbSet.AsNoTracking().Where(m => m.MeetingId == meetingId).ToListAsync();
    }
}
