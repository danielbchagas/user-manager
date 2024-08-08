using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Customers.Api.Entities;

namespace UserManager.Customers.Api.Infrastructure.Mappers;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Street)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);
        builder.Property(x => x.DeletedAt)
            .IsRequired(false);
    }
}