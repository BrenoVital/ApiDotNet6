using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("idproduto").UseIdentityColumn();
            builder.Property(p => p.CodErp).HasColumnName("coderp").HasMaxLength(10);
            builder.Property(p => p.Name).HasColumnName("nome").HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnName("preco").HasMaxLength(20);
            builder.HasMany(p => p.Purchases).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
        }
    }
}
