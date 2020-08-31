using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Wps.Domain.Concrete;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Wps.WebUI.Controllers
{
    public class DownloadController : ApiController
    {
        private EFDbContext db = new EFDbContext();

        // GET: api/Download
        public IEnumerable<string> Geet()
        {
            return new string[] { "value1", "value2" };
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get()
        {

            string zipPath = AppDomain.CurrentDomain.BaseDirectory + "sounds/sounds.zip";// HttpContext.Server.MapPath("~/sounds/sounds.zip");
            //string zipPath = HttpContext.Current.Server.MapPath("~/sounds/sounds.zip");
            //string zipPath = HostingEnvironment.MapPath("~/sounds/sounds.zip");
            // var zipPath = HttpContext.Server.MapPath("~/sounds/sounds.zip" ); //ConfigurationManager.AppSettings["FilePath"];

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            FileSecurity fs = new FileSecurity();

            var sid = new SecurityIdentifier(WellKnownSidType.BuiltinAuthorizationAccessSid, null);
            fs.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.FullControl, AccessControlType.Allow));

            var stream = new FileStream(zipPath, FileMode.Open, FileSystemRights.FullControl, FileShare.Read, 8, FileOptions.None, fs);

            // var stream = new FileStream(zipPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite,,,);
            try
            {
                if (File.Exists(zipPath))
                {
                    
                    result.Content = new StreamContent(stream);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "sounds.zip"

                    };

                }
            }
            catch (Exception ex)
            {
                //LogError.LogErrorToFile(ex);
            }
            return result;
        }

        // GET: api/Download/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Download
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Download/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Download/5
        public void Delete(int id)
        {
        }
    }
}
