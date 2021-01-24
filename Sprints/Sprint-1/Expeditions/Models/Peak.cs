using System;
using System.Collections.Generic;

namespace Expeditions.Models
{
    public partial class Peak
    {
        public Peak()
        {
            Expeditions = new HashSet<Expedition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public bool ClimbingStatus { get; set; }
        public int? FirstAscentYear { get; set; }

        public virtual ICollection<Expedition> Expeditions { get; set; }
    }
}
