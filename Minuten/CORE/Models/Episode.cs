using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minuten.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime? OriginalDate { get; set; }
        public string AltTitle { get; set; }
        public string WinnersPrize { get; set; }
        public int WinnerPanelMemberId { get; set; }
        public ICollection<PanelMember> PanelMembers { get; set; }

        public string MyComment { get; set; }
        public byte MyRating { get; set; }
    }
}