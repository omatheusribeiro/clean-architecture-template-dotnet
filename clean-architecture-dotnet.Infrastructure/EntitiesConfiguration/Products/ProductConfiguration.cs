using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using clean_architecture_dotnet.Domain.Entities.Products;

namespace clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreationDate).IsRequired();

            builder.Property(p => p.ChangeDate);

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.Value).IsRequired();

            builder.Property(p => p.ProductTypeId).IsRequired();

            builder
                .HasOne(uc => uc.Type)
                .WithMany(u => u.Product)
                .HasForeignKey(uc => uc.ProductTypeId);

            builder
                .HasMany(u => u.Sale)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    CreationDate = DateTime.UtcNow,
                    ChangeDate = null,
                    Name = "Product test",
                    Description = "Description for product test",
                    Value = 100,
                    ProductTypeId = 1,
                }); ;
        }
    }
}
