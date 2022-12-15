using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Student, Coordinator")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var userId = ((int)HttpContext.Items["userId"]).ToString();
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + userId));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

        public class DownloadRequest {
            public string fileName { get; set; }
        }

        [HttpPost("/api/Upload/download", Name = "DownloadFile")]
        [Authorize(Roles = "Student, Coordinator")]
        public IActionResult Download(DownloadRequest req)
        {
            var userId = ((int)HttpContext.Items["userId"]).ToString();

            string path = "";
            try
            {    
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + userId + "/" + req.fileName));
                if (System.IO.File.Exists(path))
                {
                    var fileContent = System.IO.File.ReadAllBytes(path);
                    return File(fileContent, "application/pdf");
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
