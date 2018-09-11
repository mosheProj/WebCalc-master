using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebCalc.Interfaces;
using WebCalc.Models;
using WebCalc.Services;

namespace WebCalc
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
            services.AddMemoryCache();
            services.AddMvc();
            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddScoped<ICalculateService, DecimalCalculateService>();
            services.AddScoped<IExpressionFormater, ExpressionFormater>();
            services.AddScoped<IOperatorEgine, OperatorEgine>();

            services.AddScoped<IOperator<decimal>, PlusOperator>();
            services.AddScoped<IOperator<decimal>, MinusOperator>();
            services.AddScoped<IOperator<decimal>, MultipleOperator>();
            services.AddScoped<IOperator<decimal>, DivideOperator>();

            services.AddScoped<IOperatorFactory, OperatorFactory>();
            services.AddScoped<IExpressionValidation, ExpressionValidation>();
            services.AddScoped<ICalculatotManager<decimal>, CalculatotManager>();
            services.AddScoped<ICalculatorEngine<decimal>, CalculatorEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
