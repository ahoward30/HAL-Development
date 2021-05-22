using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models
{

    public partial class MeetingLogModel
    {
        public MeetingLogModel()
        {
            RequestTitle = "Title";
            RequestDescription = "Description";
            MatchedUserName = "UserName";
            MatchedUserEmail = "Email";
            TimeOfMeeting = DateTime.UtcNow;
            HelpRequestTags = new List<Service>();
            meetingId = 0;
            isExpert = false;
        }

//        public List<MeetingLogModel>
//        {
//}
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
        public string MatchedUserName { get; set; }
        public string MatchedUserEmail { get; set; }
        public DateTime TimeOfMeeting { get; set; }
        public List<Service> HelpRequestTags { get; set; } = new List<Service>();
        public int meetingId { get; set; }
        public bool isExpert { get; set; }
    }
}
