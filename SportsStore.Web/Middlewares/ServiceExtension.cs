using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Entities.Context;
using SportsStore.LoggerService.Interfaces;
using SportsStore.LoggerService.LoggerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Web.Middlewares
{
    public static class ServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerMessage, LoggerMessage>();


        //public static IServiceCollection AddRepositories(this IServiceCollection services)
        //{
        //    services.AddTransient<IUnitOfWork, UnitOfWork<WalletDbContext>>();
        //    services.AddTransient<IAccountService, AccountService>();
        //    services.AddTransient<ITransactionService, TransactionService>();
        //    services.AddTransient<IAdminService, AdminService>();
        //    services.AddTransient<IUserService, UserService>();
        //    services.AddTransient<IServiceFactory, ServiceFactory>();

        //    return services;
        //}


        public static IServiceCollection AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SportsStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SportsStoreConnection"),
                     b => b.MigrationsAssembly("SportsStore.Web")
                ));


            //services.AddIdentity<User, Role>(o =>
            //{
            //    o.Password.RequireDigit = false;
            //    o.Password.RequireLowercase = false;
            //    o.Password.RequireUppercase = false;
            //    o.Password.RequireNonAlphanumeric = false;
            //    o.Password.RequiredLength = 6;
            //    o.User.RequireUniqueEmail = false;
            //    o.SignIn.RequireConfirmedEmail = false;
            //})
            //    .AddEntityFrameworkStores<WalletDbContext>()
            //    .AddDefaultTokenProviders();

            return services;
        }
    }
}
