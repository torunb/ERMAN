using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Upload(IFormCollection formData, IFormFile pdfFile)
        {
            var userId = ((int)HttpContext.Items["userID"]).ToString();

            string formType = formData["fileType"];

            string path = "";
            try
            {
                if (pdfFile.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + userId));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, formType + ".pdf"), FileMode.Create))
                    {
                        await pdfFile.CopyToAsync(fileStream);
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
        [Authorize(Roles = "Student")]
        public IActionResult Download(DownloadRequest req)
        {
            var userId = ((int)HttpContext.Items["userID"]).ToString();

            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + userId + "/" + req.fileName));
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

        [HttpPost("/api/Upload/download-coordinator", Name = "DownloadFileCoordinator")]
        [Authorize(Roles = "Coordinator")]
        public IActionResult DownloadCoordinator(DownloadRequest req)
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + req.fileName));
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

        public class FilesResponse {
            public List<string> names { get; set; }
        }


        [HttpPost("/api/Upload/view", Name = "ViewFiles")]
        [Authorize(Roles = "Student")]
        public List<string> GetUploadedFiles()
        {
            var userId = ((int)HttpContext.Items["userID"]).ToString();
            var fileNames = new List<string>();

            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/" + userId));
                if (System.IO.Directory.Exists(path))
                {
                    var directory = new DirectoryInfo(path);
                    var files = directory.GetFiles();       
                    foreach (var file in files)
                    {
                        fileNames.Add(file.Name);
                    }
                }

                return fileNames;
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

        [HttpPost("/api/Upload/view-all", Name = "ViewAllFiles")]
        [Authorize(Roles = "Coordinator")]
        public List<string> GetUploadedFilesCoordinator()
        {
            var fileNames = new List<string>();
            try
            {
                var uploadedFilesPath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles/");
                if (System.IO.Directory.Exists(uploadedFilesPath))
                {
                    var uploadedFiles = new DirectoryInfo(uploadedFilesPath);
                    var directories = uploadedFiles.GetDirectories();
                    foreach (var directory in directories)
                    {
                        var files = directory.GetFiles();
                        foreach (var file in files)
                        {
                            var result = directory.Name + "/" + file.Name;
                            fileNames.Add(result);
                        }
                    }
                }

                return fileNames;
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
