using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Permission;
using ApplicationCore.Interfaces.UserPermission;
using ApplicationCore.Services;
using ApplicationCore.Services.UserPermission;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebAPI
{
    public class Startup
    {
        const string CORS_POLICY = "CorsPolicy";
        public IConfiguration Configuration { get; }
        public string BaseApiUrl { get; set; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration,
                       IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
            BaseApiUrl = Environment.IsDevelopment() ? Configuration.GetSection("Enviroment").GetSection("DevIdentity").Value : Configuration.GetSection("Enviroment").GetSection("ProdIdentity").Value;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options =>
                                             options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            #region UserService
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Permission
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            #endregion

            #region UserPermission
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(CORS_POLICY);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
