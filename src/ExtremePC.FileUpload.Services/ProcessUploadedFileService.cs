using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.FileUpload.Services
{
    public class ProcessUploadedFileService : IProcessUploadedFileService
    {
        private readonly IDataParserService dataParserService;
        private readonly ILogger logger;

        public ProcessUploadedFileService(IDataParserService dataParserService, ILogger logger)
        {
            this.dataParserService = dataParserService;
            this.logger = logger;
        }

        public async Task Run(string path)
        {
            try
            {
                dataParserService.Parse("iru-assignment-2018.csv");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }
        
    }
}
