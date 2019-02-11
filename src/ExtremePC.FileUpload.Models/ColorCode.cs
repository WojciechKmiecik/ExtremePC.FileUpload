using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExtremePC.FileUpload.Models
{
    public class ColorCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorCodeId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
