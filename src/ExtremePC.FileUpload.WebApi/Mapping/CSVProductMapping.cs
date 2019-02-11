using ExtremePC.FileUpload.Models.CSV;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace ExtremePC.FileUpload.Services.Mapping
{
    internal class CSVProductMapping : CsvMapping<ProductCSVModel>
    {
        public CSVProductMapping() : base()
        {
            MapProperty(0, x => x.Key);
            MapProperty(1, x => x.ArtikelCode);
            MapProperty(2, x => x.ColorCode);
            MapProperty(3, x => x.Description);
            MapProperty(4, x => x.Price);
            MapProperty(5, x => x.DiscountPrice);
            MapProperty(6, x => x.DeliveredIn);
            MapProperty(7, x => x.Q1);
            MapProperty(8, x => x.Size);
            MapProperty(9, x => x.Color);
        }

    }
}
