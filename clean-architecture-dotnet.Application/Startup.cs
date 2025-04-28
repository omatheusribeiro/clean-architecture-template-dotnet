using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.Services.Users;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.Services.Products;
using clean_architecture_dotnet.Application.Services.Sales.Interfaces;
using clean_architecture_dotnet.Application.Services.Sales;
using clean_architecture_dotnet.Application.Services.Login.Interfaces;
using clean_architecture_dotnet.Application.Services.Login;
using clean_architecture_dotnet.Infrastructure.Authentication;

namespace clean_architecture_dotnet.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Authentication Services
            services.AddScoped<TokenGenerator>();
            #endregion

            #region Users Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Products Services

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();

            #endregion

            #region Sales Services

            services.AddScoped<ISaleService, SaleService>();

            #endregion

            #region Login Services

            services.AddScoped<ILoginService, LoginService>();

            #endregion

            return services;
        }
    }
}
