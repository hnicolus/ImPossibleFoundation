using ImPossibleFoundation.Infrastructure.EntityFrameworkCore;
using ImPossibleFoundation.Infrastructure.Identity;
using ImPossibleFoundation.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using NSwag;
using NSwag.Generation.Processors.Security;
using ImPossibleFoundation.Server.Filters;

namespace ImPossibleFoundation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<AppDbContext>();

            services.AddDatabaseDeveloperPageExceptionFilter();



            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilter()));

            services.AddRazorPages();
            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddOpenApiDocument(configure =>
                        {
                            configure.Title = "ImPossible Foundation API";
                            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                            {
                                Type = OpenApiSecuritySchemeType.ApiKey,
                                Name = "Authorization",
                                In = OpenApiSecurityApiKeyLocation.Header,
                                Description = "Type into the textbox: Bearer {your JWT token}."
                            });

                            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/swagger";
                settings.DocumentPath = "/api/specification.json";
            });
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
