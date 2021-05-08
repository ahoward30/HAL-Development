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
        Itmuser Itmuser { get; set; } //Name, email
        Expert Expert { get; set; } //Schedule
        public List<Service> Services { get; set; } // tags

        List<(int, double)> OfflineExpertIdsAndScores { get; set; } // matching score
    }
}