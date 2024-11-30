
using DataLayer;
using MasterGezira.API.Extensions;
using MasterGezira.API.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace MasterGezira
{
    public class Program
    {
        public static void Main(string[] args)
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
            builder.Services.AddControllers();
            //builder.Services.AddHttpContextAccessor();
            #endregion
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
           
            builder.Services.AddOpenApi();

            #region Dependency Injection
            builder.Services.AddApplicationExtensions();
            #endregion

            var app = builder.Build();

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
            app.MapOpenApi();

            #region Routing
            app.UseRouting();
           // app.UseHttpsRedirection();
            #endregion

            #region Global Error Handler
            app.UseExceptionMiddleware();
            #endregion

            #region authorization and authentication
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            //#region Routing
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //#endregion
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
            app.MapControllers();

            app.Run();
        }
    }
}
