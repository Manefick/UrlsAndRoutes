using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseMvc(routes =>
            {
                //Стандартный шаблон который указывает что если в URL не указан action то он устанавлеваеться в Index
                //routes.MapRoute(name: "default", template: "{controller}/{action}", defaults:new { action = "Index"});
                //шаблон который обрабатывает статический ЮРЛ вида :"Shop/OldAction"
                //routes.MapRoute(name: "ShopScema2", template: "Shop/OldAction", defaults: new { controller = "Customer", action = "Index" });
                //УРЛ вида Public/Home/Index  со статическим елементом "Public", применяеться шаблон вида:
                //routes.MapRoute(name: "default", template: "Public/{controller=Admin}/{action=Index}");
                //ещеодин вариан со статическим елементом URL: Xhome/index будет обработом шаблоном:
                //routes.MapRoute(name: "", template: "X{controller}/{action}");
                //второй способ задать стандартные значения controller and action
                //routes.MapRoute(name: "", template: "{controller=Home}/{action=Index}");

                //Добавления третего сегмента ЮРЛ значение которого записываеться в переменную id, если его нет то устанавливаеться DefaultId
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id=DefaultId}");
                //необезательный сегмент ЮРЛ обозначаеться именем и ?, что бы ЮРЛ был не фиксированой длины(к-ва сегментов)
                //нужно добавить * и имя например *catrhAll
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id?}/{*catchAll}");

                routes.Routes.Add(new LegacyRoute(
                    app.ApplicationServices,
                    "/articles/Windows_3.1_Overview.html",
                    "/old/.NET_1.0_Class_Library"));
                routes.MapRoute(name: "out", template: "outbount/{controller=Home}/{action=Index}");
                routes.MapRoute(name: "first", template: "New/Name{action}", defaults: new { controller = "Home" });
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
