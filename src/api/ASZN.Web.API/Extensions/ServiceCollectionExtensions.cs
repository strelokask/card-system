using ASZN.DomainModel;
using ASZN.Services;
using ASZN.Services.Interface;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using ASZN.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ASZN.Web.API.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configuration) {
            services.RegisterConfig(configuration);
            services.ConfigureDbContext(configuration);
            services.ConfigureDtoMapping();
            services.RegisterServices();


            services.AddAuthorization();
            services.ConfigureIdentity();
            services.ConfigureJWT(configuration);

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ICardService, CardsService>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterConfig(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            return serviceCollection.AddSingleton<IConfiguration>(configuration);
        }


        public static IServiceCollection ConfigureDtoMapping(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void ConfigureIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            ;
        }
        public static void ConfigureJWT(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
            var secret = jwtSettings["Secret"];

            serviceCollection
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["ValidIssuer"],
                        ValidAudience = jwtSettings["ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                    };
                });
        }
        public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return serviceCollection;
        }
    }
}
