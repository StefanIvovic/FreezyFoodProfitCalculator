using FreezyFood_Profit_Calculator.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FreezyFood_Profit_Calculator.Models
{
    public class ProfitDbContext : DbContext
    {
        public ProfitDbContext() : base("name=ProfitDbContext")
        {
        }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProfitDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Unit>()
                .HasRequired(p => p.Product);
        }

        
    }
}