using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.FileUpload.Database
{
    public class FileUploadDBContextFactory : IDesignTimeDbContextFactory<FileUploadDBContext>
    {
        public FileUploadDBContext CreateDbContext(string[] args)
        {
            var currentdir = System.IO.Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(currentdir)
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<FileUploadDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new FileUploadDBContext(builder.Options);
        }
    }
}
