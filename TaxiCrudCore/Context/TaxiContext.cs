using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCrudCore.Entities;


namespace TaxiCrudCore.Context
{
    public class TaxiContext : DbContext
    {
        public TaxiContext(DbContextOptions<TaxiContext> options) 
            : base(options)
        {
        }


        public DbSet<Auto> Autos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoadConfiguration());
            // Add other entity configurations here
        }
    }
    public class HomeCrudContextFactory : IDesignTimeDbContextFactory<TaxiContext>
    {
        public TaxiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxiContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=DB_taxist;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            return new TaxiContext(optionsBuilder.Options);
        }
    }

}
