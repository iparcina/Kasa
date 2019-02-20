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
using Kasa.Models;
using System.Web.Http.Cors;
namespace Kasa.Controllers
{
     [EnableCorsAttribute("*","*","*")]

    
    public class ProductsController : ApiController
    {
        private proizvodi_Entities1 db = new proizvodi_Entities1();
        
        // GET: api/Products
        [HttpGet]
        public IQueryable<Proizvodi> GetProizvodi()
        {
            return db.Proizvodi;
        }

        // GET: api/Products/5

        [ResponseType(typeof(Proizvodi))]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvodi proizvodi = db.Proizvodi.Find(id);
            if (proizvodi == null)
            {
                return NotFound();
            }

            return Ok(proizvodi);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvodi(int id, Proizvodi proizvodi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvodi.ID_proizvod)
            {
                return BadRequest();
            }

            db.Entry(proizvodi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodiExists(id))
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

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Proizvodi))]
        public IHttpActionResult PostProizvodi([FromBody]Proizvodi proizvodi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proizvodi.Add(proizvodi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proizvodi.ID_proizvod }, proizvodi);
        }

        // DELETE: api/Products/5

        [ResponseType(typeof(Proizvodi))]
        public IHttpActionResult DeleteProizvodi(int id)
        {
            Proizvodi proizvodi = db.Proizvodi.Find(id);
            if (proizvodi == null)
            {
                return NotFound();
            }

            db.Proizvodi.Remove(proizvodi);
            db.SaveChanges();

            return Ok(proizvodi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodiExists(int id)
        {
            return db.Proizvodi.Count(e => e.ID_proizvod == id) > 0;
        }
    }
}