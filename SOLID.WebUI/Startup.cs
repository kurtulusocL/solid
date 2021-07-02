using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SOLID.Business.Abstract;
using SOLID.Business.Concrete;
using SOLID.DataAccess.Abstract;
using SOLID.DataAccess.Concrete;
using SOLID.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.WebUI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IAboutService, AboutMenager>();
            services.AddScoped<IAboutDAL, AboutDAL>();
            services.AddScoped<ICategoryService, CategoryMenager>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<IProductService, ProductMenager>();
            services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<IProductDetailService, ProductDetailMenager>();
            services.AddScoped<IProductDetailDAL, ProductDetailDAL>();
            services.AddScoped<ICommentService, CommentMenager>();
            services.AddScoped<ICommentDAL, CommentDAL>();
            services.AddScoped<IPictureService, PictureMenager>();
            services.AddScoped<IPictureDAL, PictureDAL>();
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
