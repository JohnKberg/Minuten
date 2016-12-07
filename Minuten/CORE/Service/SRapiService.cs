using SRapi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minuten.CORE.Service
{
    public class SRapiService
    {
        public int Import(DateTime? fromDate)
        {
            int addedCount = 0;
            SRapi.SRapi api = new SRapi.SRapi();
            EpisodeArrayResponse epArrayResponse = api.GetAllProgramEpisodes(1307, fromDate);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Models.Episode episode;
                foreach (var episodeInfo in epArrayResponse.Episodes)
                {
                    episode = new Models.Episode()
                    {
                        Id = episodeInfo.Id,
                        Date = episodeInfo.Publishdateutc,
                        Title = episodeInfo.Title,
                        Description = episodeInfo.Description,
                        OriginalDate = null
                    };

                    db.Episodes.Add(episode);
                    addedCount++;
                }
                db.SaveChanges();
            }            

            return 0;
        }
    }
}