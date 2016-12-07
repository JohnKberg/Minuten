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

namespace Minuten.Controllers
{
    public class PanelMembersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PanelMembers
        public IQueryable<PanelMember> GetPanelMembers()
        {
            return db.PanelMembers;
        }

        // GET: api/PanelMembers/5
        [ResponseType(typeof(PanelMember))]
        public IHttpActionResult GetPanelMember(short id)
        {
            PanelMember panelMember = db.PanelMembers.Find(id);
            if (panelMember == null)
            {
                return NotFound();
            }

            return Ok(panelMember);
        }

        // PUT: api/PanelMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPanelMember(short id, PanelMember panelMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != panelMember.Id)
            {
                return BadRequest();
            }

            db.Entry(panelMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelMemberExists(id))
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

        // POST: api/PanelMembers
        [ResponseType(typeof(PanelMember))]
        public IHttpActionResult PostPanelMember(PanelMember panelMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PanelMembers.Add(panelMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = panelMember.Id }, panelMember);
        }

        // DELETE: api/PanelMembers/5
        [ResponseType(typeof(PanelMember))]
        public IHttpActionResult DeletePanelMember(short id)
        {
            PanelMember panelMember = db.PanelMembers.Find(id);
            if (panelMember == null)
            {
                return NotFound();
            }

            db.PanelMembers.Remove(panelMember);
            db.SaveChanges();

            return Ok(panelMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PanelMemberExists(short id)
        {
            return db.PanelMembers.Count(e => e.Id == id) > 0;
        }
    }
}