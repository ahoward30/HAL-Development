using System;
using System.Collections.Generic;

namespace Expeditions.Models
{
    public partial class TrekkingAgency
    {
        public TrekkingAgency()
        {
            Expeditions = new HashSet<Expedition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expedition> Expeditions { get; set; }
    }
}
