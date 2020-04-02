using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnimtaWebApi.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ImageController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public ImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            try
            {

                 
                for (int i = 0; i <= Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];

                    string folderName = "images";
                    string webRootPath = @"D:\OnimtaWeb\OnimtaDevWeb\src\assets\Images\ProfilePics";
                    string newPath = Path.Combine(webRootPath, folderName);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    if (file.Length > 0)
                    {
                       // string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        string  fileName = Guid.NewGuid().ToString()+".jpeg";
                      
                        string fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                   
                }

                return Json("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
    }
}
