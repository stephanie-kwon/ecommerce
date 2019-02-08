using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Ecommerce.Models
{
    public class Startup
    {
        public IConfiguration Configuration {get;}
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;    
            
                   
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YourContext>(options => options.UseMySQL(Configuration["DBInfo:ConnectionString"]));
            services.AddMvc();
            services.AddSession();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
    
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseMvc();
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["sk_test_ObpGkti5hl4OIZJbcKfPkJcg"]);
            app.UseFileServer();
        }
    }
}
