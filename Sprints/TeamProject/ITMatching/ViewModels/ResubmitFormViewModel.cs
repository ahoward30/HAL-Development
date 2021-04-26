using ITMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITMatching.ViewModels
{
    public class ResubmitFormViewModel
    {
        public HelpRequest HelpRequest { get; set; }
        public List<Service> Services { get; set; }
        public List<int> checkedBoxes { get; set; }
    }
}
