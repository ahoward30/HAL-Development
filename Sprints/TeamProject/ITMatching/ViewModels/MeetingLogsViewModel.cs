using ITMatching.Models;
using ITMatching.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.ViewModels
{
    public class MeetingLogsViewModel
    {
        //public Itmuser CurrentUser { get; set; } // User's FirstName and LastName
        //public List<Itmuser> MatchedUsers { get; set; }
        //public List<Service> Services { get; set; } // Help request tags
        //public List<Meeting> Meetings { get; set; } // Meeting date and time
        //public List<HelpRequest> HelpRequests { get; set; } // Help request title and description
        //public List<RequestService> RequestServices { get; set; } // Link services to help request
        //public List<MeetingLogsViewModel> MeetingLogModel { get; set; }

        //public MeetingLogsViewModel()
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
