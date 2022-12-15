using Microsoft.AspNetCore.Mvc;


namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
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
        public IActionResult Download(DownloadRequest req)
        {
            Console.WriteLine("req filename is: " + req.fileName);

            string path = "";
            try
            {    
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + req.fileName));
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
