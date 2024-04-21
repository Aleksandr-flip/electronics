using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.interfaces;
using Shop.descriptions;
using Shop.Models;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {
        //Retrieving data from the "dbsettings.json" file
        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connecting the "DefaultConnection" value from the "dbsettings.json" file
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            //Commands that combine an interface and a class that implements this interface
            services.AddTransient<IAllServices, ServiceRepository>();
            services.AddTransient<IServicesCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            //The service allows us to work with sessions
            services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>();
            //The service provides each user with their own shopping cart
            services.AddScoped(sp => ShopCart.GetCart(sp));
            //Mvc support in the project
            services.AddMvc();
            //Cache service
            services.AddMemoryCache();
            //Session usage service
            services.AddSession();
            //Since using 'UseMvc' to configure MVC is not supported when using Endpoint Routing. To continue using 'UseMvc' I install
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Displaying an error page
            app.UseDeveloperExceptionPage();
            //Displaying page codes
            app.UseStatusCodePages();
            //Using static files in a project such as CSS, img and others
            app.UseStaticFiles();
            //The application uses sessions
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                //When you go to the main page, the Home controller will be called by default and the Index function will be called inside this controller
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                //Added a route for displaying various categories on the site. If we do not pass action nor category, then by default the "Service" controller and the "List" function will be called
                routes.MapRoute(name: "categoryFilter", template: "Service/{action}/{category?}", defaults: new { Controller = "Service", action = "List" });
            });
            
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                //Call a function to add objects to the database
                DBObjects.Initial(content);
            }
        }
    }
}
