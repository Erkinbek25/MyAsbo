using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyAsbo.Api.Middlewares;
using MyAsbo.Data.DbContexts;
using MyAsbo.Data.IRepositories;
using MyAsbo.Data.Repositories;
using MyAsbo.Service.Interfaces;
using MyAsbo.Service.Options;
using MyAsbo.Service.Services;
using System.Text;
using Microsoft.OpenApi.Models;

namespace MyAsbo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.Configure<JwtOptions>(
                builder.Configuration.GetSection(JwtOptions.SectionName));

            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            var jwtOptions = builder.Configuration
                .GetSection(JwtOptions.SectionName)
                .Get<JwtOptions>()!;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,

                        ValidateLifetime = true

                    };
                
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Login'dan olingan tokenni kiriting (\"Bearer\" so'zisiz)"
                });

                var securityScheme = new OpenApiSecurityScheme
                {

                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {  securityScheme, Array.Empty<string>()}
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
