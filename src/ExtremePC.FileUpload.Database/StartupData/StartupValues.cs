using ExtremePC.FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.FileUpload.Database.StartupData
{
    public class StartupValues
    {
        public StartupValues()
        {
            ColorCodes = new List<ColorCode> {
                new ColorCode { ColorCodeId = 1, Name = "broek", Products = null },
                new ColorCode { ColorCodeId = 2, Name = "Kniebroek Jorge", Products = null },
                new ColorCode { ColorCodeId = 3, Name = "Jeans", Products = null },
                new ColorCode { ColorCodeId = 4, Name = "Jeans Willy", Products = null },
                new ColorCode { ColorCodeId = 5, Name = "Kniebroek Maria", Products = null },
                new ColorCode { ColorCodeId = 6, Name = "Top Wilma", Products = null },
                new ColorCode { ColorCodeId = 7, Name = "Top Annie", Products = null },
                new ColorCode { ColorCodeId = 8, Name = "Top Bill", Products = null },
                new ColorCode { ColorCodeId = 9, Name = "Steve Irwin", Products = null },
                new ColorCode { ColorCodeId = 10, Name = "Jeans Willy Boys", Products = null },
                new ColorCode { ColorCodeId = 11, Name = "Short Billy & Bobble", Products = null },
                new ColorCode { ColorCodeId = 12, Name = "jacket", Products = null },
                new ColorCode { ColorCodeId = 13, Name = "test", Products = null },
                };
            Colors = new List<Color>
            {
                new Color { ColorId = 1, Name = "grijs", Products = null },
                new Color { ColorId = 2, Name = "groen" , Products = null},
                new Color { ColorId = 3, Name = "wit" , Products = null},
                new Color { ColorId = 4, Name = "zwart" , Products = null},
                new Color { ColorId = 5, Name = "bruin" , Products = null},
                new Color { ColorId = 6, Name = "beige" , Products = null},
                new Color { ColorId = 7, Name = "rood" , Products = null},
                new Color { ColorId = 8, Name = "blauw" , Products = null},
            };
        }
        public List<Color> Colors { get;}
        public List<ColorCode> ColorCodes { get; }
    }
}
