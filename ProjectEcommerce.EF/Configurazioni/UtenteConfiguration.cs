using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEcommerce.CORE.Entities;

namespace ProjectEcommerce.EF
{
    internal class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nome).IsRequired();
            builder.Property(s => s.Username).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.Ruolo).IsRequired();
        }
    }
}