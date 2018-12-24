using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DAL.Concrete
{
    public class ETradeContext: DbContext
    {
        public ETradeContext() : base("ETradeDbConStr")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired<Category>(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey<int>(c => c.CategoryId);

        }
    }
}
