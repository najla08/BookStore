using System;
using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BookStore
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        private readonly string _policyName = "CorsPolicy";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IBookstoreRepository<Author>, AuthorDbRepository>();
            services.AddScoped<IBookstoreRepository<Book>, BookDbRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors(o => o.AddPolicy(name: _policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                       
                //.AllowCredentials();
            }));
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });
            


        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(_policyName);

            /*  app.UseMvc(route => {
                  route.MapRoute("default", "{controller=Book}/(action=Index)/{id?}");
              });*/

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
