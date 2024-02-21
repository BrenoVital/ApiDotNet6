using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;


namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("idpessoa").UseIdentityColumn();
            builder.Property(p => p.Document).HasColumnName("documento").HasMaxLength(20);
            builder.Property(p => p.Name).HasColumnName("nome").HasMaxLength(100);
            builder.Property(p => p.Phone).HasColumnName("celular").HasMaxLength(20);
            builder.HasMany(p => p.Purchases).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);
        }
    }
}
