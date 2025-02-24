﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.Services.Users;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.Services.Products;
using clean_architecture_dotnet.Application.Services.Sales.Interfaces;
using clean_architecture_dotnet.Application.Services.Sales;
using clean_architecture_dotnet.Application.Services.Login.Interfaces;
using clean_architecture_dotnet.Application.Services.Login;

namespace clean_architecture_dotnet.Application
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Users Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAddressService, UserAddresService>();
            services.AddScoped<IUserContactService, UserContactService>();

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
