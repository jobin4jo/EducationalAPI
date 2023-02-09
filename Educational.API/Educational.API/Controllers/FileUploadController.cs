using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("FileUpload")]
        public async Task<ActionResult>FileUpload(string Location)
        {
            string WebPhotoPath = "";
            try
            {
              
                if (Request.Form != null)
                {
                    var files = Request.Form.Files;
                    var file = files.Any() && files.Count > 0 ? files[0] : null;
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        string uploadFolder = Path.Combine(this._webHostEnvironment.WebRootPath, @"Uploads\");
                        string uploadPath = Path.Combine(uploadFolder + DateTime.Now.ToString("MMyyyy") + @"\");

                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        fileName = Location + "." + Path.GetExtension(fileName);

                        var filePath = Path.Combine(
                            uploadPath,
                            fileName
                        );

                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        WebPhotoPath = "https://" + HttpContext.Request.Host.Value + @"\Uploads\" + DateTime.Now.ToString("MMyyyy") + @"\" + fileName;
                    }

                }
                ///return Ok(new { filePath = WebPhotoPath });
                return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = WebPhotoPath });
            }
            catch(Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
