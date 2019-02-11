using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExtremePC.FileUpload.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremePC.FileUpload.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IProcessUploadedFileService processUploadedFileService;

        public FileUploadController(IProcessUploadedFileService processUploadedFileService)
        {
            this.processUploadedFileService = processUploadedFileService;
        }
        [HttpPost("UploadFiles")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                       await formFile.CopyToAsync(stream);
                    }
                    // To test this properly - I need frontend or postman.
                    // I could create a simple angular app to handle the frontend, but it will exceed time limit. 
                    // I used test controller and I left it intentionally - swagger - test
                    await processUploadedFileService.Run(formFile.Name);
                }
            }


            return Ok(new { count = files.Count, size, filePath });
        }
    }
}