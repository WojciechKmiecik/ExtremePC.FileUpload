using ExtremePC.FileUpload.Models.CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.FileUpload.Services
{
    public interface IDataParserService
    {
        List<ProductCSVModel> Parse(string pathToFile);
    }
}
