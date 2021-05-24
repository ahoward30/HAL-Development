using ITMatching.Models;
using System.Collections.Generic;


namespace ITMatching.ViewModels
{
    public class ExpertWaitingRoomViewModel
    {
        public Expert Expert { get; set; }
        public Dictionary<int, HelpRequest> Meetings { get; set; }
    }
}
