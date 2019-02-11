using ExtremePC.FileUpload.Models.CSV;
using ExtremePC.FileUpload.Services.Mapping;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace ExtremePC.FileUpload.WebApi.Services
{
    public class DataParserService : IDataParserService
    {
        private readonly ILogger<DataParserService> logger;

        public DataParserService(ILogger<DataParserService> logger)
        {
            this.logger = logger;
        }
        public async Task<List<ProductCSVModel>> Parse(string pathToFile)
        {
            CsvParserOptions options = new CsvParserOptions(true, ',');
            CSVProductMapping mapping = new CSVProductMapping();
            CsvParser<ProductCSVModel> parser = new CsvParser<ProductCSVModel>(options, mapping);

            try
            {
                var mappingresult = await Task.Run(() => parser.ReadFromFile(pathToFile, Encoding.UTF8).ToList());
                var result = mappingresult.Where(x => x.IsValid).Select(x => x.Result).ToList();
                return result;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }
    }
}
