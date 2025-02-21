using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Entities.Sales;
using clean_architecture_dotnet.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Products;
using clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Sales;
using clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Users;

namespace clean_architecture_dotnet.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         
        #region Users Tables

        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Products Tables

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion

        #region Sales Table

        public DbSet<Sale> Sales { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Users Configuration

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new UserAddressConfiguration());

            builder.ApplyConfiguration(new UserContactConfiguration());

            #endregion

            #region Products Configuration

            builder.ApplyConfiguration(new ProductTypeConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            #endregion

            #region Sales Configuration

            builder.ApplyConfiguration(new SaleConfiguration());

            #endregion
        }
    }
}
