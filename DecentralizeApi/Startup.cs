using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repo;
using Data.Repo.Implementation;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;
using Services.Implementation;

namespace DecentralizeApi
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
            services.AddDbContext<Context>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAccountRepository), typeof(AccountRepository));
            services.AddTransient(typeof(IConsultantRepository), typeof(ConsultantRepository));
            services.AddTransient(typeof(IProjectRepository), typeof(ProjectRepository));
            services.AddTransient(typeof(ITransactionRepository), typeof(TransactionRepository));
            services.AddTransient(typeof(IVendorRepository), typeof(VendorRepository));

            services.AddTransient(typeof(ITransactionService), typeof(TransactionService));
            services.AddTransient(typeof(IPaymentProcessorService), typeof(PaymentProcessorService));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
