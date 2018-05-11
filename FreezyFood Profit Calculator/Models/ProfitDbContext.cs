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
        public System.Data.Entity.DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Unit>()
                .HasRequired(p => p.Product);
        }

        public System.Data.Entity.DbSet<FreezyFood_Profit_Calculator.Models.Product> Products { get; set; }
    }
}