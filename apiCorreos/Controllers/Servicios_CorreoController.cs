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
using apiCorreos.Models;

namespace apiCorreos.Controllers
{
    public class Servicios_CorreoController : ApiController
    {
        private ConexionBase db = new ConexionBase();

        // GET: api/Servicios_Correo
        public IQueryable<Servicios_Correo> GetServicios_Correo()
        {
            return db.Servicios_Correo;
        }

        // GET: api/Servicios_Correo/5
        [ResponseType(typeof(Servicios_Correo))]
        public IHttpActionResult GetServicios_Correo(int id)
        {
            Servicios_Correo servicios_Correo = db.Servicios_Correo.Find(id);
            if (servicios_Correo == null)
            {
                return NotFound();
            }

            return Ok(servicios_Correo);
        }

        // PUT: api/Servicios_Correo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicios_Correo(int id, Servicios_Correo servicios_Correo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios_Correo.Id)
            {
                return BadRequest();
            }

            db.Entry(servicios_Correo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Servicios_CorreoExists(id))
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

        // POST: api/Servicios_Correo
        [ResponseType(typeof(Servicios_Correo))]
        public IHttpActionResult PostServicios_Correo(Servicios_Correo servicios_Correo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios_Correo.Add(servicios_Correo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicios_Correo.Id }, servicios_Correo);
        }

        // DELETE: api/Servicios_Correo/5
        [ResponseType(typeof(Servicios_Correo))]
        public IHttpActionResult DeleteServicios_Correo(int id)
        {
            Servicios_Correo servicios_Correo = db.Servicios_Correo.Find(id);
            if (servicios_Correo == null)
            {
                return NotFound();
            }

            db.Servicios_Correo.Remove(servicios_Correo);
            db.SaveChanges();

            return Ok(servicios_Correo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Servicios_CorreoExists(int id)
        {
            return db.Servicios_Correo.Count(e => e.Id == id) > 0;
        }
    }
}