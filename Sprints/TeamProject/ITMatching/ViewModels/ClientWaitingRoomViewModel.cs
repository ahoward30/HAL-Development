using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITMatching.Models;


namespace ITMatching.ViewModels
{
    public class ClientWaitingRoomViewModel
    {
        public HelpRequest HelpRequest { get; set; }
        public Meeting Meeting { get; set; }
    }
}
