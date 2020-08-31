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
    public class DownApiController : ApiController
    {
        private EFDbContext db = new EFDbContext();

       


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetWords()
        {

            string zipPath = AppDomain.CurrentDomain.BaseDirectory + "sounds/sounds.zip";// HttpContext.Server.MapPath("~/sounds/sounds.zip");
                                                                                         // var zipPath = HttpContext.Server.MapPath("~/sounds/sounds.zip" ); //ConfigurationManager.AppSettings["FilePath"];
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(zipPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
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

       
    }
}