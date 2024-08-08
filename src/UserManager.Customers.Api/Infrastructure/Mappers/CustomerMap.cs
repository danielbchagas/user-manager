using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Customers.Api.Entities;

namespace UserManager.Customers.Api.Infrastructure.Mappers;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);
        
        builder.Property(x => x.DeletedAt)
            .IsRequired(false);
        
        builder.HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<Address>(x => x.CustomerId);
        
        builder.HasQueryFilter(x => x.DeletedAt != null);
    }
}