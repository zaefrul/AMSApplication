using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BMSApplication.Models;

namespace BMSApplication.Controllers
{
    public class Sell_PriceController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sell_Price
        public IQueryable<Sell_Price> GetSell_Price()
        {
            return db.Sell_Price;
        }

        // GET: api/Sell_Price/5
        [ResponseType(typeof(Sell_Price))]
        public async Task<IHttpActionResult> GetSell_Price(int id)
        {
            Sell_Price sell_Price = await db.Sell_Price.FindAsync(id);
            if (sell_Price == null)
            {
                return NotFound();
            }

            return Ok(sell_Price);
        }

        // PUT: api/Sell_Price/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSell_Price(int id, Sell_Price sell_Price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sell_Price.Id)
            {
                return BadRequest();
            }

            db.Entry(sell_Price).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sell_PriceExists(id))
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

        // POST: api/Sell_Price
        [ResponseType(typeof(Sell_Price))]
        public async Task<IHttpActionResult> PostSell_Price(Sell_Price sell_Price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sell_Price.Add(sell_Price);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sell_Price.Id }, sell_Price);
        }

        // DELETE: api/Sell_Price/5
        [ResponseType(typeof(Sell_Price))]
        public async Task<IHttpActionResult> DeleteSell_Price(int id)
        {
            Sell_Price sell_Price = await db.Sell_Price.FindAsync(id);
            if (sell_Price == null)
            {
                return NotFound();
            }

            db.Sell_Price.Remove(sell_Price);
            await db.SaveChangesAsync();

            return Ok(sell_Price);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sell_PriceExists(int id)
        {
            return db.Sell_Price.Count(e => e.Id == id) > 0;
        }
    }
}