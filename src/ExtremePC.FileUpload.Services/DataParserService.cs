using ExtremePC.FileUpload.Models.CSV;
using ExtremePC.FileUpload.Services.Mapping;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace ExtremePC.FileUpload.Services
{
    public class DataParserService : IDataParserService
    {
        private readonly ILogger logger;

        public DataParserService(ILogger logger)
        {
            this.logger = logger;
        }
        public List<ProductCSVModel> Parse(string pathToFile)
        {
            CsvParserOptions options = new CsvParserOptions(true, ',');
            CSVProductMapping mapping = new CSVProductMapping();
            CsvParser<ProductCSVModel> parser = new CsvParser<ProductCSVModel>(options, mapping);

            try
            {
                var result = parser.ReadFromFile(pathToFile, Encoding.UTF8).ToList() ;
                result = result.ToList();
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }
    }
}
