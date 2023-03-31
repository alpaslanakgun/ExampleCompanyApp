using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExampleCompanyApp.Core;
using ExampleCompanyApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleCompanyApp.Repository
{
    public class ExampleCompanyDbContext:DbContext
    {
        public ExampleCompanyDbContext(DbContextOptions<ExampleCompanyDbContext> options):base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
