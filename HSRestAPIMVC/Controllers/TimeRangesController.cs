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
    public class TimeRangesController : ApiController
    {
        private readonly IRepository<TimeRange> _tr = new Facade().GetTimeRangeRepository();

        // GET: api/TimeRanges
        public List<TimeRange> GetTimeRanges()
        {
            return _tr.GetAll();
        }

        // GET: api/TimeRanges/5
        [ResponseType(typeof(TimeRange))]
        public IHttpActionResult GetTimeRange(int id)
        {
            TimeRange timeRange = _tr.Get(id);
            if (timeRange == null)
            {
                return NotFound();
            }

            return Ok(timeRange);
        }

        // PUT: api/TimeRanges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeRange(int id, TimeRange timeRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeRange.ID)
            {
                return BadRequest();
            }
            _tr.Update(timeRange);
            //db.Entry(timeRange).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TimeRangeExists(id))
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

        // POST: api/TimeRanges
        [ResponseType(typeof(TimeRange))]
        public IHttpActionResult PostTimeRange(TimeRange timeRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tr.Create(timeRange);

            return CreatedAtRoute("DefaultApi", new { id = timeRange.ID }, timeRange);
        }

        // DELETE: api/TimeRanges/5
        [ResponseType(typeof(TimeRange))]
        public IHttpActionResult DeleteTimeRange(int id)
        {
            TimeRange timeRange = _tr.Get(id);
            if (timeRange == null)
            {
                return NotFound();
            }

            _tr.Remove(timeRange);

            return Ok(timeRange);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool TimeRangeExists(int id)
        {
            return _tr.GetAll().Count(e => e.ID == id) > 0;
        }
    }
}