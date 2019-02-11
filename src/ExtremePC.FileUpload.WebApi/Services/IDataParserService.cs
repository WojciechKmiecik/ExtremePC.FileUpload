using ExtremePC.FileUpload.Models.CSV;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public interface IDataParserService
    {
        Task<List<ProductCSVModel>> Parse(string pathToFile);
    }
}
