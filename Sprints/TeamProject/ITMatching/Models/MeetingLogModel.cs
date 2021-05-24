using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models
{

    public class MeetingLogModel
    {
        //public MeetingLogModel()
        //{
        //    RequestTitle = "Title";
        //    RequestDescription = "Description";
        //    MatchedUserName = "UserName";
        //    MatchedUserEmail = "Email";
        //    TimeOfMeeting = DateTime.UtcNow;
        //    HelpRequestTags = new List<Service>();
        //    MeetingId = 0;
        //    IsExpert = false;
        //}

        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
        public string MatchedUserName { get; set; }
        public string MatchedUserEmail { get; set; }
        public DateTime TimeOfMeeting { get; set; }
        public List<Service> HelpRequestTags { get; set; } = new List<Service>();
        public int MeetingId { get; set; }
        public bool IsExpert { get; set; }
    }
}
