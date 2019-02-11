using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExtremePC.FileUpload.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        //strange formating, I saw collors in it, so i could cut it out, but leters like "acup" were hard to decyrypt
        public string Key { get; set; }
        // same here - Malformed data to reject ? no clue, so stirng here.
        public string ArtikelCode { get; set; }
        // all were common, so for migration i took them away to separate table
        public int ColorCodeId { get; set; }
        public ColorCode ColorCode { get; set; }
        public string Description { get; set; }
        // price and discount could have decimal point
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        //i imagine that in future it will be easier to calculate delivery dates
        public int DeliveredInMin { get; set; }
        public int DeliveredInMax { get; set; }
        // i dont get it - especially "NOINDEX" - so i left it as it was
        public string Q1 { get; set; }
        public int Size { get; set; }
        //same here - common colors, saving a space in DB
        public int ColorId { get; set; }
        public Color Color { get; set; }


    }
}
