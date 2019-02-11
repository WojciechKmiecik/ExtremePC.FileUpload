using ExtremePC.FileUpload.Models;
using ExtremePC.FileUpload.Models.CSV;
using ExtremePC.FileUpload.WebApi.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public class NormalizeDataService : INormalizeDataService
    {
        private readonly ILogger<NormalizeDataService> logger;

        public NormalizeDataService(ILogger<NormalizeDataService> logger)
        {
            this.logger = logger;
        }
        public async Task<List<Product>> NormalizeProducts(List<ProductCSVModel> productCSVModels, List<ColorCode> colorCodes, List<Color> colors)
        {
            if (productCSVModels == null || !productCSVModels.Any())
            {
                throw new ArgumentNullException(nameof(productCSVModels));
            }
            List<Product> products = new List<Product>();
            try
            {
                foreach (var productCSV in productCSVModels)
                {
                    var product = new Product();
                    product.ArtikelCode = productCSV.ArtikelCode;
                    product.ColorId = colors.Where(x => x.Name.ToLowerInvariant() == productCSV.Color.ToLowerInvariant()).Select(x => x.ColorId).FirstOrDefault();
                    product.ColorCodeId = colorCodes.Where(x => x.Name.ToLowerInvariant() == productCSV.ColorCode.ToLowerInvariant()).Select(x => x.ColorCodeId).FirstOrDefault();
                    var extractedDays = productCSV.DeliveredIn.Before(" ");
                    product.DeliveredInMin = Convert.ToInt32(extractedDays.Before("-"));
                    product.DeliveredInMax = Convert.ToInt32(extractedDays.After("-"));
                    product.Description = productCSV.Description;
                    product.DiscountPrice = Convert.ToDecimal(productCSV.DiscountPrice);
                    product.Key = productCSV.Key;
                    product.Price = Convert.ToDecimal(productCSV.Price);
                    product.Q1 = productCSV.Q1;
                    product.Size = productCSV.Size;
                    products.Add(product);
                }
            }
            catch (ArgumentException ae)
            {
                logger.LogError(ae.Message, ae);
                throw;
            }
            return products;
        }
    }
}
