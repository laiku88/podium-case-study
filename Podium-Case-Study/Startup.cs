using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Podium_Case_Study.Data;
using Podium_Case_Study.Data.DbContext;
using Podium_Case_Study.Data.Repositories;
using Podium_Case_Study.Domain;

namespace Podium_Case_Study
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(services =>
                    services.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<MortgageAppContext>(options =>
            {
                options.UseSqlServer(
                    Configuration["ConnectionStrings:MortgageAppContextDb"]);
            });
            services.AddTransient<MortgageProductsSeeder>();
            services.AddTransient<ApplicantProcessor>();
            services.AddTransient<MortgageProcessor>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IMortgageProductRepository, MortgageProductRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
