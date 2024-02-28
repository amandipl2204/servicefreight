using ServiceFreight.BusinessLogic.Extensions;
using ServiceFreight.DataAccess.Extensions;
using ServiceFreight.Models.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Diagnostics.CodeAnalysis;
using Utilities.Extensions;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            Log.Information("Hosting Environment: {Environment}", builder.Environment.EnvironmentName);

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Logging.AddSerilog();

            builder.Services.AddApiVersioning();

            builder.Services.AddBusinessLogicDependencies(builder.Configuration, builder.Environment);

            builder.Services.AddDataAccessDependencies(builder.Configuration, builder.Environment);

            builder.Services.AddModelValidators();

            builder.Services.AddUtilitiesDependencies();

            builder.Services.AddHealthChecks();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Manufacture API",
                    Description = "Manufacture Freight API"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
            });

            builder.Services.AddSwaggerGen();

            //services cors
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            WebApplication? app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manufacture API"));

            app.MapHealthChecks(builder.Configuration["HealthCheckUrl"]).AllowAnonymous();

            app.MapControllers();
            app.UseCors("corsapp");
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Error in Startup");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}