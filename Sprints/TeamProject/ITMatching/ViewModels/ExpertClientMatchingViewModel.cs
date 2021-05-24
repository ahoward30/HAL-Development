using ITMatching.Models;
using ITMatching.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITMatching.ViewModels
{
    public class ExpertClientMatchingViewModel
    {
        public List<Itmuser> Itmusers { get; set; } //Name, email
        public List<Service> Services { get; set; }
        public List<(int, double, double)> OfflineExpertIdsAndScores { get; set; } // matching score
        public List<ExpertService> ExpertTags { get; set; }
    }
}