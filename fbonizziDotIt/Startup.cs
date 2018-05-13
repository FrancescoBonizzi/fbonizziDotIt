using fbonizziDotIt.Data;
using fbonizziDotIt.Data.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace fbonizziDotIt
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDataProvider, JsonFileDataProvider>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app
                .UseDeveloperExceptionPage()
                .UseStaticFiles()
                .UseDefaultFiles()
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Pages}/{action=Index}/{id?}");
                });
        }
    }
}
