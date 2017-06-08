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
using BizzDesk_Leap_API.Models;
using BizzDesk_Leap_API.DAL;
using System.Web;
using System.IO;
using System.Threading.Tasks;

namespace BizzDesk_Leap_API.Controllers
{
    public class FileController : ApiController
    {
        private LeapDB db = new LeapDB();

        // GET api/File
        public IQueryable<Files> GetFile()
        {
            return db.File;
        }

        // GET api/File/5
        [ResponseType(typeof(Files))]
        public IHttpActionResult GetFile(int id)
        {
            Files file = db.File.Find(id);
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        public Task<HttpResponseMessage> PostFile()
        {
            List<string> savedFilePath = new List<string>();
            
            if(!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string rootPath = HttpContext.Current.Server.MapPath("~/UploadedImages");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<HttpResponseMessage>(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }

                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        string newFileName = Guid.NewGuid() + Path.GetExtension(name);
                        File.Move(item.LocalFileName, Path.Combine(rootPath, newFileName));

                        Uri Base_Uri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        string fileRelativePath = "~/UploadedImages/" + newFileName;
                        Uri fileFullPath = new Uri(Base_Uri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savedFilePath.Add(fileFullPath.ToString());
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }

                return Request.CreateResponse(HttpStatusCode.Created, savedFilePath);
            });
            return task;
        }

        
        // PUT api/File/5
        public IHttpActionResult PutFile(int id, Files file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != file.ID)
            {
                return BadRequest();
            }

            db.Entry(file).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        // POST api/File
        [HttpPost]
        [ResponseType(typeof(Files))]
        public IHttpActionResult PostFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection  
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                if (httpPostedFile != null)
                {
                    Files imgupload = new Files();
                    int length = httpPostedFile.ContentLength;
                    imgupload.Content = new byte[length]; //get imagedata  
                    httpPostedFile.InputStream.Read(imgupload.Content, 0, length);
                    imgupload.FileName = Path.GetFileName(httpPostedFile.FileName);
                    db.File.Add(imgupload);
                    db.SaveChanges();
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);
                    // Save the uploaded file to "UploadedFiles" folder  
                    httpPostedFile.SaveAs(fileSavePath);
                    return Ok("Image Uploaded");
                }
            }
            return Ok("Image is not Uploaded");
        }  
        
        /*public IHttpActionResult PostFile(Files file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.File.Add(file);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = file.ID }, file);
        }*/

        // DELETE api/File/5
        [ResponseType(typeof(Files))]
        public IHttpActionResult DeleteFile(int id)
        {
            Files file = db.File.Find(id);
            if (file == null)
            {
                return NotFound();
            }

            db.File.Remove(file);
            db.SaveChanges();

            return Ok(file);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileExists(int id)
        {
            return db.File.Count(e => e.ID == id) > 0;
        }
    }
}