using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<Message>> GetMessagesByMeetingIdAsync(int meetingId);
    }
}
