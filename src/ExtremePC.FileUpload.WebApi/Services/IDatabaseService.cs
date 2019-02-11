using ExtremePC.FileUpload.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public interface IDatabaseService
    {
        Task<List<Color>> GetColorsAsync();

        Task<List<ColorCode>> GetColorCodesAsync();
        Task BulkInsertNormalizedData(List<Product> normalizedData);
    }
}