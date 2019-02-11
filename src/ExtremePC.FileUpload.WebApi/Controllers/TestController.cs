using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtremePC.FileUpload.Services;
using ExtremePC.FileUpload.WebApi.Services;

namespace ExtremePC.FileUpload.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IProcessUploadedFileService processUploadedFileService;

        public TestController(IProcessUploadedFileService processUploadedFileService)
        {
            this.processUploadedFileService = processUploadedFileService;
        }
        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            await processUploadedFileService.Run("iru-assignment-2018.csv");
            return await Task.FromResult(Ok());
        }
    }
}