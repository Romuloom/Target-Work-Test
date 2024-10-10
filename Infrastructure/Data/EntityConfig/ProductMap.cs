using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Active).IsRequired();
            builder.HasOne(p => p.Client)
                   .WithMany()
                   .HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
