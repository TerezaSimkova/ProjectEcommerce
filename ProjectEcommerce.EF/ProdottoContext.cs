using Microsoft.EntityFrameworkCore;
using ProjectEcommerce.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.EF
{
    public class ProdottoContext : DbContext
    {
        public DbSet<Prodotto> Prodotti { get; set; }
        public ProdottoContext()
        {

        }

        public ProdottoContext(DbContextOptions<ProdottoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		    Database=ProdottiDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Prodotto>(new ProdottoConfiguration());
        }
    }
}
