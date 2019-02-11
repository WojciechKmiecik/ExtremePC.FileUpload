using ExtremePC.FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.FileUpload.Database
{
    public class FileUploadDBContext : DbContext
    {
        public FileUploadDBContext(DbContextOptions<FileUploadDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var startupValues = new StartupData.StartupValues();

            // hasdata requires .ToArray(). if not - then EF throws unpleasant exception : "Parameter count mismatch."

            modelBuilder.Entity<Color>().HasData(startupValues.Colors.ToArray());
            modelBuilder.Entity<ColorCode>().HasData(startupValues.ColorCodes.ToArray());

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Color)
                .WithMany(c => c.Products)
                .HasForeignKey(fk => fk.ColorId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ColorCode)
                .WithMany(c => c.Products)
                .HasForeignKey(fk => fk.ColorCodeId);

            

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorCode> ColorCodes { get; set; }
    }
}
