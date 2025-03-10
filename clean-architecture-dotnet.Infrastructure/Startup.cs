﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using clean_architecture_dotnet.Infrastructure.Context;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Products;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales;

namespace clean_architecture_dotnet.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                      .EnableSensitiveDataLogging());

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            #region Users Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAddressRepository, UserAddresRepository>();
            services.AddScoped<IUserContactRepository, UserContactRepository>();

            #endregion

            #region Products Repositories

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            #endregion

            #region Sale Repository

            services.AddScoped<ISaleRepository, SaleRepository>();

            #endregion

            return services;
        }
    }
}
