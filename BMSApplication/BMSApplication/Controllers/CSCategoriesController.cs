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
    public class CSCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CSCategories
        public IQueryable<CSCategory> GetCSCategories()
        {
            return db.CSCategories;
        }

        // GET: api/CSCategories/5
        [ResponseType(typeof(CSCategory))]
        public async Task<IHttpActionResult> GetCSCategory(int id)
        {
            CSCategory cSCategory = await db.CSCategories.FindAsync(id);
            if (cSCategory == null)
            {
                return NotFound();
            }

            return Ok(cSCategory);
        }

        // PUT: api/CSCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCSCategory(int id, CSCategory cSCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cSCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(cSCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CSCategoryExists(id))
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

        // POST: api/CSCategories
        [ResponseType(typeof(CSCategory))]
        public async Task<IHttpActionResult> PostCSCategory(CSCategory cSCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CSCategories.Add(cSCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cSCategory.Id }, cSCategory);
        }

        // DELETE: api/CSCategories/5
        [ResponseType(typeof(CSCategory))]
        public async Task<IHttpActionResult> DeleteCSCategory(int id)
        {
            CSCategory cSCategory = await db.CSCategories.FindAsync(id);
            if (cSCategory == null)
            {
                return NotFound();
            }

            db.CSCategories.Remove(cSCategory);
            await db.SaveChangesAsync();

            return Ok(cSCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CSCategoryExists(int id)
        {
            return db.CSCategories.Count(e => e.Id == id) > 0;
        }
    }
}