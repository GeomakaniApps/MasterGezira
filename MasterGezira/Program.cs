
using Core.Infrastruture.JWTValidation;
using DataLayer;
using MasterGezira.API.Extensions;
using MasterGezira.API.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataLayer.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MasterGezira
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Reference loop handling
           // builder.Services.AddControllers()
                //.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            #endregion

            #region DB connection
            builder.Services.AddDbContext<MasterDBContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            #endregion
            // Add services to the container.
            #region ActionFilters
            //builder.Services.AddMemoryCache();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            { //Solve Json.Serialization error
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddXmlDataContractSerializerFormatters();
            //builder.Services.AddHttpContextAccessor();
            #endregion
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            #region configures Swagger to add JWT authentication support to the Swagger UI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                        "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                    }   
                     });

            });
            #endregion

            #region Dependency Injection
            builder.Services.AddApplicationExtensions();
            #endregion

            builder.Services.AddCustomAuthentication(builder.Configuration);


            //#region Automatically run pending migrations
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var dbContext = services.GetRequiredService<MasterDBContext>();
            //    var logger = services.GetRequiredService<ILogger<Program>>();

            //    try
            //    {
            //        dbContext.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError(ex, "An error occurred while migrating the database.");
            //    }
            //}
            //#endregion

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
            

            

           
            var app = builder.Build();

            #region Update Lookup
            using (var scope = app.Services.CreateScope())
            {
                var seedLookupDate = scope.ServiceProvider.GetRequiredService<LookupUpdater>();
                await seedLookupDate.SeedLookupDataAsync();
            }
            #endregion

            #region Global Error Handler
            app.UseExceptionMiddleware();
            #endregion

            #region Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region authorization and authentication
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion
            app.MapControllers();

            app.Run();
        }
    }
    public class AddFileUploadFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.RequestBody != null)
            {
                foreach (var content in operation.RequestBody.Content)
                {
                    if (content.Key.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase))
                    {
                        content.Value.Schema.Properties.Add("File", new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        });
                    }
                }
            }
        }
    }
    }
