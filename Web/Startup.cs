using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Interfaces.HttpClientSender;
using Web.Interfaces.Permission;
using Web.Interfaces.User;
using Web.Interfaces.UserPermission;
using Web.Services.HttpClientSender;
using Web.Services.Permission;
using Web.Services.User;
using Web.Services.UserPermission;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientSenderService, HttpClientSenderService>();
            services.AddScoped<IUserViewModelService, UserViewModelService>();
            services.AddScoped<IPermissionViewModelService, PermissionViewModelService>();
            services.AddScoped<IUserPermissionViewModelService, UserPermissionViewModelService>();

            services.AddRazorPages();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/User/UserList", "");
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Error";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });
        }
    }
}
