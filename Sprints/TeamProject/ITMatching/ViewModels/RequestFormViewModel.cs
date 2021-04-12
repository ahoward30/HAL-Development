using ITMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITMatching.ViewModels
{
    public class RequestFormViewModel
    {
        public HelpRequest HelpRequest { get; set; }
        public List<Service> Services { get; set; }
    }
}
