using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tax> Taxes { get; set; }

        public DbSet<ProductTax> ProductTaxes { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<RawMaterialProvider> RawMaterialProviders { get; set; }

        public DbSet<RawMaterial> RawMaterials { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<RawMaterialProviderBrand> RawMaterialProviderBrands { get; set; }

        public DbSet<Preparation> Preparations { get; set; }

        public DbSet<PreparationItem> PreparationItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.;Database=IlCapoContext;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true");
            }
        }
    }
}
