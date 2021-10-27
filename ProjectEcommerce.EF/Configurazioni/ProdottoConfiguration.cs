using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEcommerce.CORE;

namespace ProjectEcommerce.EF
{
    internal class ProdottoConfiguration : IEntityTypeConfiguration<Prodotto>
    {
        public void Configure(EntityTypeBuilder<Prodotto> builder)
        {
            builder.ToTable("Prodotto"); 
            builder.HasKey(c => c.Id); 
            builder.Property(c => c.CodiceProdotto).IsRequired();
            builder.Property(c => c.Descrizione).IsRequired();
            builder.Property(c => c.PrezzoFornitore).IsRequired();
        }
    }
}