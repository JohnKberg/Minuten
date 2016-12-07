using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRapi.Response
{
    public class EpisodeArrayResponse
    {
        public EpisodeArrayResponse()
        {
            this.Episodes = new List<Episode>();
        }

        public List<Episode> Episodes { get; set; }
    }
}
