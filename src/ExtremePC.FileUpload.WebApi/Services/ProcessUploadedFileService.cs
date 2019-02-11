using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public class ProcessUploadedFileService : IProcessUploadedFileService
    {
        private readonly IDataParserService dataParserService;
        private readonly INormalizeDataService normalizeDataService;
        private readonly IDatabaseService databaseService;
        private readonly ILogger<ProcessUploadedFileService> logger;

        public ProcessUploadedFileService(IDataParserService dataParserService, 
            INormalizeDataService normalizeDataService, 
            IDatabaseService databaseService,
            ILogger<ProcessUploadedFileService> logger)
        {
            this.dataParserService = dataParserService;
            this.normalizeDataService = normalizeDataService;
            this.databaseService = databaseService;
            this.logger = logger;
        }

        public async Task Run(string path)
        {
            try
            {
                var parsedData = await dataParserService.Parse(path);
                var colorsData = await databaseService.GetColorsAsync();
                var colorCodesData = await databaseService.GetColorCodesAsync();
                var normalizedData = await normalizeDataService.NormalizeProducts(parsedData, colorCodesData, colorsData);
                await databaseService.BulkInsertNormalizedData(normalizedData);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }
        
    }
}
