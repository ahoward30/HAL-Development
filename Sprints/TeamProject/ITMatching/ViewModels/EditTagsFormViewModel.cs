using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITMatching.Models;

namespace ITMatching.ViewModels
{
    public class EditTagsFormViewModel
    {
        public List<int> ExpertServicesIDs { get; set; }
        public List<Service> Services { get; set; }
    }
}
