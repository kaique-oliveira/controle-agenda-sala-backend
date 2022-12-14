using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace AgendaSala.Auth.Configuracoes
{
    public static class Configuracoes
    {
        public static void ConfigurarToken(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(ConfigurarKeySecret()),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void ConfigurarAutorizacoes(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("usuario", policy => policy.RequireClaim("tipo", "usuario"));
                options.AddPolicy("admin", policy => policy.RequireClaim("tipo", "admin"));
            });
        }

        public static void ConfigurarCors(this IServiceCollection services)
        {
            services.AddCors();
        }

        public static void ConfigurarPoliticasGlobais(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        private static byte[] ConfigurarKeySecret()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();

            byte[] key = Encoding.ASCII.GetBytes(configuration["KeySecret:Secret"]);

            return key;
        }

       

    }
}
