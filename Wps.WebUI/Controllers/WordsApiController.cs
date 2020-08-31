using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Wps.Domain.Concrete;
using Wps.Domain.Entities;
using Wps.WebUI.Models;

namespace Wps.WebUI.Controllers
{
    public class WordsApiController : ApiController
    {
        private EFDbContext db = new EFDbContext();

        // GET: api/WordsApi
        public IEnumerable<Wordsr> GetWords()
        {
            var wp = from k in db.Words
                     select new Wordsr
                     {
                         WordID = k.WordID,
                         English = k.English,
                         Swahili = k.Swahili,
                         CategoryID = k.CategoryID,
                         Sound = k.Sound
                     };
            return wp.ToList();
        }


        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage DownloadFile()
        //{

        //    string zipPath = AppDomain.CurrentDomain.BaseDirectory + "sounds/sounds.zip";// HttpContext.Server.MapPath("~/sounds/sounds.zip");
        //                                                                                 // var zipPath = HttpContext.Server.MapPath("~/sounds/sounds.zip" ); //ConfigurationManager.AppSettings["FilePath"];
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    var stream = new FileStream(zipPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        //    try
        //    {
        //        if (File.Exists(zipPath))
        //        {

        //            result.Content = new StreamContent(stream);
        //            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //            {
        //                FileName = "sounds.zip"

        //            };

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //LogError.LogErrorToFile(ex);
        //    }
        //    return result;
        //}

        // GET: api/WordsApi/5
        //[ResponseType(typeof(Word))]
        //public async Task<IHttpActionResult> GetWord(int id)
        //{
        //    var wp = from k in db.Words
        //             where k.WordID == id
        //             select new Wordsr
        //             {
        //                 WordID = k.WordID,
        //                 English = k.English,
        //                 Swahili = k.Swahili,
        //                 CategoryID = k.CategoryID,
        //                 Sound = k.Sound
        //             };


        //    if (wp == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(wp);
        //}

        // PUT: api/WordsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWord(int id, Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != word.WordID)
            {
                return BadRequest();
            }

            db.Entry(word).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/WordsApi
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> PostWord(Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Words.Add(word);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = word.WordID }, word);
        }

        // DELETE: api/WordsApi/5
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> DeleteWord(int id)
        {
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            db.Words.Remove(word);
            await db.SaveChangesAsync();

            return Ok(word);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordExists(int id)
        {
            return db.Words.Count(e => e.WordID == id) > 0;
        }
    }
}