using SecurityLending.DAL;
using SecurityLending.models;
using SecurityLending.services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SecurityLenders.DAL.abstraction;
using Microsoft.Extensions.Configuration;
using SecurityLending.services.abstraction;
using Microsoft.Extensions.DependencyInjection;
namespace SecurityLending.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "SecurityLending.API", Version = "v1" }));
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<SecurityLendingDbContext>(options =>
                    options.UseInMemoryDatabase("SecurityLendingsDb"));
            }
            else
            {
                services.AddDbContext<SecurityLendingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped(provider => (ISecurityLendingDbContext<Lead>)provider.GetService(typeof(SecurityLendingDbContext)));
            services.AddScoped(provider => (ISecurityLendingDbContext<Borrower>)provider.GetService(typeof(SecurityLendingDbContext)));
            services.AddScoped(provider => (ISecurityLendingDbContext<Lender>)provider.GetService(typeof(SecurityLendingDbContext)));

            services.AddTransient<ICustomerRepository<Lead>    , CustomerRepository<Lead>>();
            services.AddTransient<ICustomerRepository<Borrower>    , CustomerRepository<Borrower>>();
            services.AddTransient<ICustomerRepository<Lender>    , CustomerRepository<Lender>>();

            services.AddTransient<ICustomersService<Lender>, CustomerService<Lender>>();
            services.AddTransient<ICustomersService<Borrower>, CustomerService<Borrower>>();
            services.AddTransient<ICustomersService<Lead>, CustomerService<Lead>>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecurityLending.API v1"));
            }
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
