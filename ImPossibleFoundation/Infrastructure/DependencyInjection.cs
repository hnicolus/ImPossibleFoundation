using CodeClinic.Infrastructure.Identity;
using CodeClinic.Infrastructure.Services;
using ImPossibleFoundation.Clocking;
using ImPossibleFoundation.Common;
using ImPossibleFoundation.Data;
using ImPossibleFoundation.DomainEvents;
using ImPossibleFoundation.Identity;
using ImPossibleFoundation.Infrastructure;
using ImPossibleFoundation.Infrastructure.EntityFrameworkCore;
using ImPossibleFoundation.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImPossibleFoundation
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("ImPossibleDb"));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            }

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<AppRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, AppDbContext>();

            services.AddTransient<IClock, ClockService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
                {
                    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
                });

            return services;
        }
    }
}
