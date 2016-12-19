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
using HSRestAPI_DLL;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPIMVC.Controllers
{
    public class HairdressersController : ApiController
    {
        private readonly IRepository<Hairdresser> _hr = new Facade().GetHairdresserRepository();

        // GET: api/Hairdressers
        [HttpGet]
        public IList<Hairdresser> GetUsers()
        {
            return _hr.GetAll();
        }

        // GET: api/Hairdressers/5
        [HttpGet]
        [ResponseType(typeof(Hairdresser))]
        public IHttpActionResult GetHairdresser(int id)
        {
            Hairdresser hairdresser = _hr.Get(id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            return Ok(hairdresser);
        }

        // PUT: api/Hairdressers/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairdresser(int id, Hairdresser hairdresser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairdresser.ID)
            {
                return BadRequest();
            }

            if (_hr.Update(hairdresser) == null)
            {
                return NotFound();
            }
            ;
            //db.Entry(hairdresser).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!HairdresserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hairdressers
        [ResponseType(typeof(Hairdresser))]
        public IHttpActionResult PostHairdresser(Hairdresser hairdresser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _hr.Create(hairdresser);
            return CreatedAtRoute("DefaultApi", new { id = hairdresser.ID }, hairdresser);
        }

        // DELETE: api/Hairdressers/5
        [ResponseType(typeof(Hairdresser))]
        public IHttpActionResult DeleteHairdresser(int id)
        {
            Hairdresser hairdresser = _hr.Get(id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            _hr.Remove(hairdresser);
            return Ok(hairdresser);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool HairdresserExists(int id)
        {
            return _hr.GetAll().Count(e => e.ID == id) > 0;
        }
    }
}