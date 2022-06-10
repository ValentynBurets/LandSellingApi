using WebAPI.Configurations;
using Data.EF;
using Data.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Business.Contract.Services.Authentication;
using Business.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
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
            services.AddDbContext<LandSellingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LandSellingContext")));

            services.AddDbContext<LandSellingIdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LandSellingIdentityContext")));

            services.ConfigureIdentity();

            services.AddAuthorization();
            services.AddAuthentication();

            services.ConfigurePayment(Configuration);

            services.ConfigureJWT(Configuration);


            //Define and use the default CORS policy to allow everyone and anything
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin()
                          .Build();
                });
            });

            services.AddControllers();
            services.AddRepository();

            services.AddScoped<IAuthManager, AuthManager>();
            services.AddTransient<IProfileRegistrationService, ProfileRegistrationService>();

            services.AddAutoMapper(typeof(MapperInitializer));

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Land Selling WebAPI v1", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            

            services.AddMvc(option =>
            {
                // Отключаем маршрутизацию конечных точек на основе endpoint-based logic из EndpointMiddleware
                // и продолжаем использование маршрутизации на основе IRouter. 
                option.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser().RequireAuthenticatedUser().Build();
                option.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //This middleware is used reports app runtime errors in development environment.  
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }
            else
            {
                //This middleware is catches exceptions thrown in production environment.   
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.    
                app.UseHsts(); //adds the Strict-Transport-Security header.    
            }

            //This middleware is used to redirects HTTP requests to HTTPS.  
            app.UseHttpsRedirection();

            //This middleware is used to route requests.   
            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //This middleware is used to authorizes a user to access secure resources.  
            app.UseAuthorization();

            //This middleware is used to add Razor Pages endpoints to the request pipeline.  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
