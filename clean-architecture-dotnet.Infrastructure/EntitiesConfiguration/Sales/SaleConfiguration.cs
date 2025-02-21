﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Sales
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreationDate).IsRequired();

            builder.Property(p => p.ChangeDate);

            builder.Property(p => p.TotalValue).IsRequired();

            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.ProductId).IsRequired();

            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.Sale)
                .HasForeignKey(uc => uc.UserId);

            builder
                .HasOne(uc => uc.Product)
                .WithMany(u => u.Sale)
                .HasForeignKey(uc => uc.ProductId);

            builder.HasData(
                new Sale
                {
                    Id = 1,
                    CreationDate = DateTime.UtcNow,
                    ChangeDate = null,
                    TotalValue = 100,
                    UserId = 1,
                    ProductId = 1,
                }); ;
        }
    }
}
