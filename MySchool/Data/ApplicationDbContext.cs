using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySchool.Models.Auth;
using MySchool.Models.User;

namespace MySchool.Data;

public class ApplicationDbContext : DbContext
{
    
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var baseDirectory = Directory.GetCurrentDirectory();
        var filePath =
            "/home/brunosantos/Documentos/_studys/Alura/c#/apps/my-school/MySchool/appsettings.json";
      
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(filePath)
                .Build();
            var connectionString =
                configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
    public DbSet<User> Users { get; set; }
  
}