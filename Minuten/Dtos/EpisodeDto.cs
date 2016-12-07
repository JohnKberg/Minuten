using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minuten.Dtos
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime? OriginalDate { get; set; }
        public string AltTitle { get; set; }
        public string WinnersPrize { get; set; }
        public int WinnerPanelMemberId { get; set; }
        public ICollection<PanelMemberDto> PanelMembers { get; set; }

        public string MyComment { get; set; }
        public byte MyRating { get; set; }
    }
}