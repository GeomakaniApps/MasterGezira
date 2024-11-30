using Core.Infrastruture.RepositoryPattern.Repository;
using Core.Infrastruture.UnitOfWork;
using DataLayer;
using MasterGezira.API.Middlewares;
using System.Reflection;

namespace MasterGezira.API.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<ExceptionMiddleware>();


        services.AddScoped(typeof(IUnitOfWork), services =>
        {
            return services.GetRequiredService<MasterDBContext>();
        });

        return services;
    }
}
