using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Minuten;
using Minuten.Models;
using Minuten.Dtos;
using AutoMapper;

namespace Minuten.Controllers
{
    public class EpisodesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Episodes
        public IQueryable<Episode> GetEpisodes()
        {
            return db.Episodes.OrderBy(e => e.Date);
        }

        // GET: api/Episodes/5
        [ResponseType(typeof(Episode))]
        public IHttpActionResult GetEpisode(int id)
        {
            Episode episode = db.Episodes.Include(e => e.PanelMembers).Single(e => e.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Episode, EpisodeDto>(episode));
        }

        // PUT: api/Episodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEpisode(int id, EpisodeDto episodeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != episodeDto.Id)
            {
                return BadRequest();
            }

            var episode = db.Episodes.SingleOrDefault(e => e.Id == id);

            if (episode == null)
                return NotFound();

            Mapper.Map(episodeDto, episode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/episodes/import/{fromDate:datetime?}")]
        public IHttpActionResult Import(DateTime? fromDate = null)
        {
            CORE.Service.SRapiService SRservice = new CORE.Service.SRapiService();

            SRservice.Import(fromDate);

            return Ok();
        }

        #region DISABLED ACTIONS

        //// POST: api/Episodes
        //[ResponseType(typeof(Episode))]
        //public IHttpActionResult PostEpisode(Episode episode)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Episodes.Add(episode);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = episode.Id }, episode);
        //}

        //// DELETE: api/Episodes/5
        //[ResponseType(typeof(Episode))]
        //public IHttpActionResult DeleteEpisode(int id)
        //{
        //    Episode episode = db.Episodes.Find(id);
        //    if (episode == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Episodes.Remove(episode);
        //    db.SaveChanges();

        //    return Ok(episode);
        //}

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EpisodeExists(int id)
        {
            return db.Episodes.Count(e => e.Id == id) > 0;
        }
    }
}