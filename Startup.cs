using CarWashApi.Configurations;
using CarWashApi.DTOs;
using CarWashApi.Models;
using CarWashApi.Repository;
using CarWashApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

namespace CarWashApi
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
            
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:51350")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .WithExposedHeaders()
                                            .AllowCredentials();
                    });
            });

            services.AddControllers();
            services.AddAutoMapper(typeof(MapperConfig));
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });



            services.AddDbContext<CarWashContext>
               (x => x.UseSqlServer(Configuration.GetConnectionString("Constr")));

            //addScoped - service type, when we call http request it creates new instance 

            services.AddScoped<IRepository<UserProfile, int>, UserProfileRepository>();
            services.AddScoped<UserProfileService, UserProfileService>();


            services.AddScoped<IViewInvoiceRepository, ViewInvoiceRepository>();
            services.AddScoped<ViewInvoiceService, ViewInvoiceService>();


            services.AddScoped<IViewWashersRepository, ViewWashersRepository>();
            services.AddScoped<ViewWasherService, ViewWasherService>();

            services.AddScoped<IViewCustomersRepository, ViewCustomersRepository>();
            services.AddScoped<ViewCustomerService, ViewCustomerService>();

            services.AddScoped<ILoginRepository<Login, int>, LoginRepository>();
            services.AddScoped<LoginService, LoginService>();

            services.AddScoped<IPackage, PackageRepository>();
            services.AddScoped<PackageService, PackageService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderService, OrderService>();



            services.AddScoped<IRegisterRepository<CreateUserDto, UserProfile>, RegisterRepository>();
            services.AddScoped<RegisterService, RegisterService>();

            services.AddScoped<IToken, TokenRepository>();






            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
        };
    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarWashApi v1"));
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials


            app.UseHttpsRedirection();


            app.UseAuthentication();
        
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
