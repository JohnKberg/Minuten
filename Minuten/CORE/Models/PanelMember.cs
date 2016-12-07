using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minuten.Models
{
    public class PanelMember
    {
        public Int16 Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
