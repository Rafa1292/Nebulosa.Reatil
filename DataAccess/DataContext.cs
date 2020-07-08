using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.;Database=IlCapoContext;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true");
            }
        }
    }
}
