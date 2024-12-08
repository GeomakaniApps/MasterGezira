using Core.Infrastruture.RepositoryPattern.Repository;
using Core.Infrastruture.UnitOfWork;
using DataLayer;
using DataLayer.Services;
using Domain.Common;
using Domain.Helper;
using Domain.Interfaces;
using Domain.Interfaces.AuthInterfaces;
using Domain.Services;
using Domain.Services.AuthService;
using MasterGezira.API.Middlewares;
using System.Reflection;

namespace MasterGezira.API.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAreaService, AreaService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<ExceptionMiddleware>();
        services.AddTransient<OperationResult>();
        services.AddScoped<LookupUpdater>();
        services.AddAutoMapper(typeof(Mapping));


        services.AddScoped(typeof(IUnitOfWork), services =>
        {
            return services.GetRequiredService<MasterDBContext>();
        });

        return services;
    }
}
