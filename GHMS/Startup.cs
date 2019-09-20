using GHMS.Core;
using GHMS.Core.Settings;
using GHMS.DataModel.Data;
using GHMS.DataModel.Models.Common;
using GHMS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using GHMS.Repository.Abstract;
using GHMS.Service.Abstract;
using GHMS.Service.Concrete;
using GHMS.Repository.Concrete;

namespace GHMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutomapperConfig.Configure();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GHMSDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                // Default User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789|";
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;


            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<GHMSDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("GHMSDbConnection")));

            #region Dependency Injection
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IHospitalRepository, HospitalRepository>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            #endregion

            #region JWT Configuration
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? ""))
                    };


                });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                //The generated Swagger JSON file will have these properties.
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger XML Api for GHMS",
                    Version = "v1",
                });

                //Locate the XML file being generated by ASP.NET...
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                });
            });
            #endregion

            #region Setting File Mapping
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddSession();
            var JWTSection = Configuration.GetSection("Jwt");
            services.Configure<JWTSettings>(JWTSection);
            #endregion


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            SeedData(userManager, roleManager);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc();
            //loggerFactory.AddSerilog();
            app.UseSwagger();

            //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api for GHMS v1");
            });
            app.UseSwaggerUI();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
           

        }

        public  static void SeedData
      (UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedRoles
            (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                (Roles.SuperAdmin.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.SuperAdmin.ToString();
                IdentityResult roleResult = roleManager.
                 CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                (Roles.HospitalAdmin.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.HospitalAdmin.ToString();
                // role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync
                (Roles.Doctor.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Doctor.ToString();
                IdentityResult roleResult = roleManager.
                 CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync
                (Roles.JuniorDoctor.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.JuniorDoctor.ToString();
                IdentityResult roleResult = roleManager.
                 CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync
                (Roles.Nurse.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Nurse.ToString();
                IdentityResult roleResult = roleManager.
               CreateAsync(role).Result;
            }
        }
        public static void SeedUsers
            (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync
                     ("Groot").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Groot";
                user.Email = "Groot@gmail.com";
               
                IdentityResult result = userManager.CreateAsync
                    (user, "Groot@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                        Roles.SuperAdmin.ToString()).Wait();
                }
            }



        }
    }
}
