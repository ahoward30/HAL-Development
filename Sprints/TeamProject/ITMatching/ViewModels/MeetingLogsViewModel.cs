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
        public Itmuser CurrentUser { get; set; } // User's FirstName and LastName
        public List<Itmuser> MatchedUsers { get; set; }
        public List<Service> Services { get; set; } // Help request tags
        public List<Meeting> Meetings { get; set; } // Meeting date and time
        public List<HelpRequest> HelpRequests { get; set; } // Help request title and description
        public List<RequestService> RequestServices { get; set; } // Link services to help request
        public List<MeetingLogsViewModel> MeetingLogModel { get; set; }
    }
}
