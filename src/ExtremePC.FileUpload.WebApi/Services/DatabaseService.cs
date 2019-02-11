using ExtremePC.FileUpload.Database;
using ExtremePC.FileUpload.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly FileUploadDBContext dBContext;
        private readonly ILogger<DatabaseService> logger;

        public DatabaseService(FileUploadDBContext dBContext, ILogger<DatabaseService> logger)
        {
            this.dBContext = dBContext;
            this.logger = logger;
        }

        public async Task<List<Color>> GetColorsAsync()
        {
            return await dBContext.Colors.ToListAsync();
        }

        public async Task<List<ColorCode>> GetColorCodesAsync()
        {
            return await dBContext.ColorCodes.ToListAsync();
        }

        public async Task BulkInsertNormalizedData(List<Product> normalizedData)
        {
            dBContext.ChangeTracker.AutoDetectChangesEnabled = false;
            //foreach (var product in normalizedData)
            //{
            //    dBContext.Products.Add(product);
            //}
            await dBContext.BulkInsertAsync<Product>(normalizedData);
            dBContext.ChangeTracker.AutoDetectChangesEnabled = true;

        }
    }
}
