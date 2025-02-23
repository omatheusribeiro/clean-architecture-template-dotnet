using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Products;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clean_architecture_dotnet.Application
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Users Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region Products Repositories

            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            #region Sale Repository

            services.AddScoped<ISaleRepository, SaleRepository>();

            #endregion

            return services;
        }
    }
}
