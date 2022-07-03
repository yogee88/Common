using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CoreDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CoreDbContext(DbContextOptions options) : base(options)
        {
        }

        //public CoreDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("WebApiDatabase");
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            }
            // in memory database used for simplicity, change to a real db for production applications
            //options.UseInMemoryDatabase("TestDb");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBid> ProductBid { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
      .HasKey(p => new { p.UserId, p.AddressId });
            modelBuilder.Entity<Product>()
      .HasKey(p => new { p.UserId, p.ProductId });
            modelBuilder.Entity<ProductBid>()
  .HasKey(p => new { p.ProductBidId, p.BidderId });
            //    modelBuilder.Entity<Address>()
            //    .Property(b => b.Id)
            //    .ValueGeneratedOnAdd();

            //    modelBuilder.Entity<User>()
            //    .Property(b => b.Address)
            //    .HasComputedColumnSql("[Id]")
            //    .ValueGeneratedOnAdd();
        }

    }
}
