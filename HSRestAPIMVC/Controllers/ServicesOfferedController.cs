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
    public class ServicesOfferedController : ApiController
    {
        private readonly IRepository<ServiceOffered> _sor = new Facade().GetServiceOfferedRepository();

        // GET: api/ServicesOffered
        public IList<ServiceOffered> GetServicesOffered()
        {
            return _sor.GetAll();
        }

        // GET: api/ServicesOffered/5
        [ResponseType(typeof(ServiceOffered))]
        public IHttpActionResult GetServiceOffered(int id)
        {
            ServiceOffered serviceOffered = _sor.Get(id);
            if (serviceOffered == null)
            {
                return NotFound();
            }

            return Ok(serviceOffered);
        }

        // PUT: api/ServicesOffered/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceOffered(int id, ServiceOffered serviceOffered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceOffered.ID)
            {
                return BadRequest();
            }

            _sor.Update(serviceOffered);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ServicesOffered
        [ResponseType(typeof(ServiceOffered))]
        public IHttpActionResult PostServiceOffered(ServiceOffered serviceOffered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _sor.Create(serviceOffered);

            return CreatedAtRoute("DefaultApi", new { id = serviceOffered.ID }, serviceOffered);
        }

        // DELETE: api/ServicesOffered/5
        [ResponseType(typeof(ServiceOffered))]
        public IHttpActionResult DeleteServiceOffered(int id)
        {
            ServiceOffered serviceOffered = _sor.Get(id);
            if (serviceOffered == null)
            {
                return NotFound();
            }

            _sor.Remove(serviceOffered);

            return Ok(serviceOffered);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ServiceOfferedExists(int id)
        {
            return _sor.GetAll().Count(e => e.ID == id) > 0;
        }
    }
}