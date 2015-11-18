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
using PictureProject.Models;

namespace PictureProject.Controllers
{
    public class InstagramImagesController : ApiController
    {
        private PictureProjectContext db = new PictureProjectContext();

        // GET: api/InstagramImages
        public IQueryable<InstagramImage> GetInstagramImages()
        {
            return db.InstagramImages;
        }

        // GET: api/InstagramImages/5
        [ResponseType(typeof(InstagramImage))]
        public async Task<IHttpActionResult> GetInstagramImage(int id)
        {
            InstagramImage instagramImage = await db.InstagramImages.FindAsync(id);
            if (instagramImage == null)
            {
                return NotFound();
            }

            return Ok(instagramImage);
        }

        // PUT: api/InstagramImages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstagramImage(int id, InstagramImage instagramImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instagramImage.Id)
            {
                return BadRequest();
            }

            db.Entry(instagramImage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstagramImageExists(id))
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

        // POST: api/InstagramImages
        [ResponseType(typeof(InstagramImage))]
        public async Task<IHttpActionResult> PostInstagramImage(InstagramImage instagramImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstagramImages.Add(instagramImage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = instagramImage.Id }, instagramImage);
        }

        // Non-post, non-api save image to database
        [ResponseType(typeof(InstagramImage))]
        public async void SaveImage(InstagramImage instagramImage)
        {
            if (ModelState.IsValid)
            {
                db.InstagramImages.Add(instagramImage);
                await db.SaveChangesAsync();
            }   
        }


        // DELETE: api/InstagramImages/5
        [ResponseType(typeof(InstagramImage))]
        public async Task<IHttpActionResult> DeleteInstagramImage(int id)
        {
            InstagramImage instagramImage = await db.InstagramImages.FindAsync(id);
            if (instagramImage == null)
            {
                return NotFound();
            }

            db.InstagramImages.Remove(instagramImage);
            await db.SaveChangesAsync();

            return Ok(instagramImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstagramImageExists(int id)
        {
            return db.InstagramImages.Count(e => e.Id == id) > 0;
        }
    }
}