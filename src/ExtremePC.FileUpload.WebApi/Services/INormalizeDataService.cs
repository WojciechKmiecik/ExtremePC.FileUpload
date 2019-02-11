using ExtremePC.FileUpload.Models;
using ExtremePC.FileUpload.Models.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public interface INormalizeDataService
    {
        Task<List<Product>> NormalizeProducts(List<ProductCSVModel> productCSVModels, List<ColorCode> colorCodes, List<Color> colors);
    }
}
