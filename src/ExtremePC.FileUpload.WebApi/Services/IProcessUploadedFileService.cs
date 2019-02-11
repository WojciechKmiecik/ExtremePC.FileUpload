using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public interface IProcessUploadedFileService
    {
        Task Run(string path);
    }
}
